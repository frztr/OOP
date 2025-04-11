public class AddDtoCreator
{
    public static string CreateDto(Entity entity, string layer)
    {
        return $@"
using System.ComponentModel.DataAnnotations;
namespace Global;
public class Add{entity.Name}{layer}Dto
{{
{String.Join("\n", entity.Props
.Where(x => !(x.PK && x.Identity)
&& AppContext.Get().AllowedValues.Contains(x.Type))
.Select(x =>
{
    string prop = "";
    if (x.IsRequired || (x.PK && !x.Identity))
        prop += $"\t[Required]\n";
    if (x.HasMaxLength.HasValue)
        prop += $"\t[StringLength({x.HasMaxLength.Value})]\n";
    prop += $"\tpublic {x.Type}{((x.PK || x.Identity || x.IsRequired) ? "" : "?")} {x.Name} {{ get; set; }}";
    return prop;
}))}
}}";

    }
}