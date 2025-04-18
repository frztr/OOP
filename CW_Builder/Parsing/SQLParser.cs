using System.Globalization;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

public class SQLParser
{
    static string projectFolder = "/Data";
    public static void Parse(string text)
    {
        // Console.WriteLine(text);
        List<Entity> entities = new List<Entity>();
        if (!Directory.Exists($"{AppContext.Get().ProjectPath}{projectFolder}/Data/"))
            Directory.CreateDirectory($"{AppContext.Get().ProjectPath}{projectFolder}/Data/");
        if (!Directory.Exists($"{AppContext.Get().ProjectPath}{projectFolder}/DataMap/"))
            Directory.CreateDirectory($"{AppContext.Get().ProjectPath}{projectFolder}/DataMap/");
        var table_content = "create table (\"?[\\w]+\"?){1}[\\s]?\\({1}\\s*[\\w\\s\\(\\)0-9,\"]+;";
        var tables = Regex.Matches(text, table_content);
        foreach (var table in tables)
        {
            // Console.WriteLine("_______");
            var _table = Regex.Match(table.ToString(), table_content);
            var table_name = _table.Groups[1].Captures[0].ToString().Replace("\"", "");
            // Console.WriteLine(table.ToString());
            var table_cont = Regex.Replace(_table.ToString().Replace(");", ""), "create table (\"?[\\w]+\"?){1}[\\s]?\\({1}\\s*", "");
            var rows = table_cont.Split(",\n");
            var foreign_keys = rows.Where(x => x.Contains("foreign key"));
            var fields = rows.Where(x => !foreign_keys.Contains(x));
            Entity entity = new Entity();
            entity.Name = table_name.ToString();
            foreach (var field in fields)
            {
                var words = field.Split(' ');
                var prop = new EntityProp();
                prop.Name = words[0];
                prop.Type = words[1];
                if (field.Contains("not null")) prop.IsRequired = true;
                if (field.Contains("default")) prop.Default = Regex.Replace(field, "default\\(([0-9]+){1}\\)", "");
                if (field.Contains("primary key")) prop.PK = true;
                if (field.Contains("unique")) prop.Unique = true;
                entity.Props.Add(prop);
            }
            foreach (var key in foreign_keys)
            {
                var _keyMatch = Regex.Match(key, "(foreign[\\s]+key[\\s]+(\\([\\w]+\\)){1} references (\"?[\\w]+\"?\\([\\w]+\\))){1}");
                // Console.WriteLine(key);
                var fk_name = _keyMatch.Groups[2].Captures[0].Value.Replace("(", "").Replace(")", "");
                var _ref = _keyMatch.Groups[3].Captures[0].Value.Replace(")", "").Replace("\"", "").Split("(");
                var ref_table = _ref[0];
                var ref_field = _ref[1];
                var prop = entity.Props.FirstOrDefault(x => x.Name == fk_name);
                prop.FK = ref_table;
                prop.FK_Field = ref_field;
            }

            entities.Add(entity);
        }

        for (int i = 0; i < entities.Count; i++)
        {
            var f_tables = entities[i].Props.Where(x => x.FK != null);
            for (int j = 0; j < f_tables.Count(); j++)
            {
                var prop = f_tables.Skip(j).FirstOrDefault();
                var f_table = entities.FirstOrDefault(x => x.Name == prop.FK);
                // Console.WriteLine(new { entity = entities[i].Name, prop.Name,prop.FK, f_table });
                EntityProp f_prop;
                if (!prop.PK)
                {
                    f_prop = new EntityProp()
                    {
                        Type = $"ICollection<{ToPascalCase(entities[i].Name)}>",
                        Name = FixManyEnds($"{ToPascalCase(entities[i].Name)}s")
                    };
                }
                else
                {
                    f_prop = new EntityProp()
                    {
                        Type = $"{ToPascalCase(entities[i].Name)}",
                        Name = $"{ToPascalCase(entities[i].Name)}"
                    };
                }
                f_table.Props.Add(f_prop);
            }
        }

        foreach (var entity in entities)
        {
            string _class = $@"using System.ComponentModel.DataAnnotations;
public class {ToPascalCase(entity.Name)}{{
    {String.Join("\n\t", entity.Props.Select(x =>
            {
                var prop = "";
                var type = "";
                if (x.PK)
                {
                    prop += "[Required]\n\t";
                }
                if (x.Type.Contains("varchar"))
                {
                    var value = x.Type.Replace("varchar(", "").Replace(")", "");
                    prop += $"[StringLength({value})]\n\t";
                    x.HasMaxLength = Convert.ToInt32(value);
                    type = "string";
                }
                if (x.Type == "boolean")
                {
                    type = "bool";
                }
                if (new List<string>() { "smallserial", "smallint", "int2" }.Contains(x.Type))
                {
                    type = "short";
                }
                if (new List<string>() { "serial", "int", "int4" }.Contains(x.Type))
                {
                    type = "int";
                }
                if (new List<string>() { "bigint", "int8" }.Contains(x.Type))
                {
                    type = "long";
                }
                if (new List<string>() { "date", "datetime", "timestamp" }.Contains(x.Type))
                {
                    type = "DateTime";
                }
                if (x.Type.Contains("numeric"))
                {
                    type = "decimal";
                }
                if (type == "")
                {
                    type = x.Type;
                }
                prop += $@"public {type}{((x.IsRequired || x.PK || x.Identity || x.Default != null || x.Type.Contains("ICollection")) ? "" : "?")} {ToPascalCase(x.Name)} {{ get;set; }}";
                if (x.FK != null)
                {
                    prop += $"\n\tpublic {ToPascalCase(x.FK)} {ToPascalCase(x.FK)} {{get;set;}}";
                }
                return prop;
            }))}
}}";
            string map = $@"using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Global;
public class {ToPascalCase(entity.Name)}Map : IEntityTypeConfiguration<{ToPascalCase(entity.Name)}>
{{
    public void Configure(EntityTypeBuilder<{ToPascalCase(entity.Name)}> builder)
    {{
        builder.ToTable(""{entity.Name}"");
        builder.HasKey(d => d.{ToPascalCase(entity.Props.FirstOrDefault(x => x.PK).Name)});
        {String.Join("\n\t\t", entity.Props.Where(x =>
            {
                if (new List<string>() { "boolean","serial", "smallserial", "int", "int2", "int8", "int4", "bigint", "datetime", "date", "timestamp", "smallint", "integer" }.Contains(x.Type)
                || x.Type.Contains("varchar") || x.Type.Contains("numeric"))
                    return true;
                return false;
            }).Select(x =>
                {
                    var ads = "";
                    if (new List<string>() { "smallserial", "serial" }.Contains(x.Type)) ads += ".ValueGeneratedOnAdd()";
                    if (x.HasMaxLength != null) ads += $".HasMaxLength({x.HasMaxLength})";
                    if (x.IsRequired) ads += ".IsRequired()";
                    return $@"builder.Property(d => d.{ToPascalCase(x.Name)}).HasColumnName(""{x.Name}""){ads};";
                }))}
        {String.Join("\n\t\t", entity.Props.Where(x => x.Unique).Select(x =>
                {
                    return $@"builder.HasIndex(v => v.{ToPascalCase(x.Name)}).IsUnique();";
                }))}
                    
        {String.Join("\n\n\t\t", entity.Props.Where(x => x.FK != null).Select(x =>
                {
                    return $@"builder.HasOne(d => d.{ToPascalCase(x.FK)})
                .With{(x.PK ? "One" : "Many")}(e => e.{FixManyEnds($"{ToPascalCase(entity.Name)}{(x.PK ? "" : "s")}")})
                .HasForeignKey{(!x.PK ? "" : $"<{ToPascalCase(entity.Name)}>")}(d => d.{ToPascalCase(x.Name)});";
                }))}    
        
    }}
}}";
            File.WriteAllText($"{AppContext.Get().ProjectPath}{projectFolder}/Data/{ToPascalCase(entity.Name)}.cs", _class);
            File.WriteAllText($"{AppContext.Get().ProjectPath}{projectFolder}/DataMap/{ToPascalCase(entity.Name)}Map.cs", map);
            // Console.WriteLine(_class);
            // Console.WriteLine(map);
        }

    }

    public static string ToPascalCase(string original)
    {
        Regex invalidCharsRgx = new Regex("[^_a-zA-Z0-9]");
        Regex whiteSpace = new Regex(@"(?<=\s)");
        Regex startsWithLowerCaseChar = new Regex("^[a-z]");
        Regex firstCharFollowedByUpperCasesOnly = new Regex("(?<=[A-Z])[A-Z0-9]+$");
        Regex lowerCaseNextToNumber = new Regex("(?<=[0-9])[a-z]");
        Regex upperCaseInside = new Regex("(?<=[A-Z])[A-Z]+?((?=[A-Z][a-z])|(?=[0-9]))");

        // replace white spaces with undescore, then replace all invalid chars with empty string
        var pascalCase = invalidCharsRgx.Replace(whiteSpace.Replace(original, "_"), string.Empty)
            // split by underscores
            .Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries)
            // set first letter to uppercase
            .Select(w => startsWithLowerCaseChar.Replace(w, m => m.Value.ToUpper()))
            // replace second and all following upper case letters to lower if there is no next lower (ABC -> Abc)
            .Select(w => firstCharFollowedByUpperCasesOnly.Replace(w, m => m.Value.ToLower()))
            // set upper case the first lower case following a number (Ab9cd -> Ab9Cd)
            .Select(w => lowerCaseNextToNumber.Replace(w, m => m.Value.ToUpper()))
            // lower second and next upper case letters except the last if it follows by any lower (ABcDEf -> AbcDef)
            .Select(w => upperCaseInside.Replace(w, m => m.Value.ToLower()));

        return string.Concat(pascalCase);
    }

    public static string FixManyEnds(string input)
    {
        return Regex.Replace(input, @"ys$", @"ies");
    }
}