using System.Text.Json.Serialization;

public class QueryDtoCreator
{
    public static string CreateDto(Entity entity, string layer)
    {
        return $@"
    {(layer != "Repository" ? "using Microsoft.AspNetCore.Mvc;" : "")}
    public class {entity.Name}Query{layer}Dto
    {{
        public int Count {{ get; set; }} = 50;

        public int Offset {{ get; set; }} = 0;
        {(entity.ExtendedSearch ? String.Join("\n", entity.Props.Select(x =>
        {
            string type = x.Type.Replace("?","");
            if (type == "int" || type == "decimal" || type == "short" || type == "long" || type == "DateTime")
                return $@"
        {(layer == "Controller" ? $@"[FromQuery(Name = ""{x.Name}[gt]"")]" : "")}
        public {type}? {x.Name}_GT {{get; set;}}
        {(layer == "Controller" ? $@"[FromQuery(Name = ""{x.Name}[gte]"")]" : "")}
        public {type}? {x.Name}_GTE {{get; set;}}
        {(layer == "Controller" ? $@"[FromQuery(Name = ""{x.Name}[lt]"")]" : "")}
        public {type}? {x.Name}_LT {{get; set;}}
        {(layer == "Controller" ? $@"[FromQuery(Name = ""{x.Name}[lte]"")]" : "")}
        public {type}? {x.Name}_LTE {{get; set;}}
        {(layer == "Controller" ? $@"[FromQuery(Name = ""{x.Name}[eq]"")]" : "")}
        public {type}? {x.Name}_EQ {{get; set;}}";
            if (type == "string")
                return $@"
        {(layer == "Controller" ? $@"[FromQuery(Name = ""{x.Name}[eq]"")]" : "")}
        public {type}? {x.Name}_EQ {{get; set;}}
        {(layer == "Controller" ? $@"[FromQuery(Name = ""{x.Name}[like]"")]" : "")}
        public {type}? {x.Name}_LIKE {{get; set;}}";
            return "";
        }).ToList()) : "")}
    }}";
    }
}