using System.Text.Json.Serialization;

public class QueryDtoCreator
{
    public static string CreateDto(Entity entity, string layer)
    {
        return $@"
    using Microsoft.AspNetCore.Mvc;
    public class {entity.Name}Query{layer}Dto
    {{
        public int Count {{ get; set; }} = 50;

        public int Offset {{ get; set; }} = 0;
        {(entity.ExtendedSearch ? String.Join("\n", entity.Props.Select(x =>
        {
            if (x.Type == "int" || x.Type == "decimal" || x.Type == "short" || x.Type == "long" || x.Type == "DateTime")
                return $@"
        {(layer == "Controller" ? $@"[FromQuery(Name = ""{x.Name}[gt]"")]" : "")}
        public {x.Type}? {x.Name}_GT {{get; set;}}
        {(layer == "Controller" ? $@"[FromQuery(Name = ""{x.Name}[gte]"")]" : "")}
        public {x.Type}? {x.Name}_GTE {{get; set;}}
        {(layer == "Controller" ? $@"[FromQuery(Name = ""{x.Name}[lt]"")]" : "")}
        public {x.Type}? {x.Name}_LT {{get; set;}}
        {(layer == "Controller" ? $@"[FromQuery(Name = ""{x.Name}[lte]"")]" : "")}
        public {x.Type}? {x.Name}_LTE {{get; set;}}
        {(layer == "Controller" ? $@"[FromQuery(Name = ""{x.Name}[eq]"")]" : "")}
        public {x.Type}? {x.Name}_EQ {{get; set;}}";
            if (x.Type == "string")
                return $@"
        {(layer == "Controller" ? $@"[FromQuery(Name = ""{x.Name}[eq]"")]" : "")}
        public {x.Type}? {x.Name}_EQ {{get; set;}}
        {(layer == "Controller" ? $@"[FromQuery(Name = ""{x.Name}[like]"")]" : "")}
        public {x.Type}? {x.Name}_LIKE {{get; set;}}";
            return "";
        }).ToList()) : "")}
    }}";
    }
}