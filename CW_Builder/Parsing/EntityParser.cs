using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

public class EntityParser
{
    public static Entity Parse(FileInfo file)
    {
        var fileText = File.ReadAllText($"{AppContext.Get().ProjectPath}/Data/Data/{file.Name.Replace(".cs", "")}.cs");
        var entityName = Regex.Match(fileText, @"public class ([\w]+)").Value.Replace("public class ", "");
        // var entityBody = new Regex(@"((public class ([\w]+)[\W]{1}[\\{]{1})|([\\{]{1} get; set; [\\}]{1})|([\\}]{1}))+").Replace(
        //     Regex.Match(fileText, @"public class ([\w]+)[\W]{1}[\\{]{1}[\w\W]+[\\}]{1}").Value, "");
        var props = Regex.Matches(fileText, @"\w+ [\w<>]+[?]* \w+\s*\{\s*get;\s*set;\s*\}");
                // Regex.Matches(fileText, @"\w+\s+[\w\<\>]+[?]*\s+\w+[\s]{{\s*get;\s*set;\s*}}").ToList().ForEach(x=>Console.WriteLine(x));
        // Regex.Matches(fileText, @"\w+\s+[\w><]+[?]*\s+\w+\s*{{\s*get;\s*set;\s*}}").ToList().ForEach(x=>Console.WriteLine(x));
        var entProps = props.ToList().Select(x =>
        {
            var s = x.Value.Split(" ");
            // Console.WriteLine(x);
            return new EntityProp()
            {
                Modificator = s[0],
                Type = s[1],
                Name = s[2]
            };
        });

        Entity entity = new Entity()
        {
            Name = entityName,
            Props = entProps.ToList()
        };

        ParseDataMaps(entity);
        return entity;
    }

    private static void ParseDataMaps(Entity entity)
    {
        var fileText = File.ReadAllText($"{AppContext.Get().ProjectPath}/Data/DataMap/{entity.Name}Map.cs");

        foreach (var prop in entity.Props)
        {
            if (Regex.IsMatch(fileText, $@"builder.HasKey\([\w]+[\W]*=>[\W]*[\w]+.{prop.Name}\)"))
            {
                prop.PK = true;
            }
            var entityRow = Regex.Match(fileText, @$"builder.Property\([\w]+[\W]*=>[\W]*[\w]+.{prop.Name}\).HasColumnName\(""[\w]+""\)[.a-zA-Z0-9\(\)]+").Value;
            if (Regex.IsMatch(entityRow, @$"ValueGeneratedOnAdd\(\)"))
            {
                prop.Identity = true;
            }
            if (Regex.IsMatch(entityRow, @$"HasMaxLength\([\w]+\)"))
            {
                prop.HasMaxLength = Convert.ToInt32(Regex.Replace(Regex.Match(entityRow, @$"HasMaxLength\([\w]+\)").Value, @"(HasMaxLength\(|\))", ""));
            }
            if (Regex.IsMatch(entityRow, @$"IsRequired\(\)"))
            {
                prop.IsRequired = true;
            }
            //.HasPrecision(7, 3)
        }

        var foreign_keys = Regex.Matches(fileText, @"builder.HasOne\([\w]+[\W]*=>[\W]*[\w]+.([\w]+)\)[\W]*.WithMany\([\w]+[\W]*=>[\W]*[\w]+.[\w]+\)[\W]*.HasForeignKey\([\w]+[\W]*=>[\W]*[\w]+.([\w]+)\)");
        foreach (var foreign_key in foreign_keys.ToList())
        {
            var entityFK = foreign_key.Groups[1].Captures.FirstOrDefault().Value;
            var propFK = foreign_key.Groups[2].Captures.FirstOrDefault().Value;
            var prop = entity.Props.FirstOrDefault(x => x.Name == propFK);
            // Console.WriteLine(new {entityFK,propFK,entity = JsonConvert.SerializeObject(entity)});
            // Console.WriteLine(JsonConvert.SerializeObject(new { propFK, entityFK, prop, entity }));
            prop.FK = entityFK;
        }

    }
}