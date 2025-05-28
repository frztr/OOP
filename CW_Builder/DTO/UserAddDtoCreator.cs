public class UserAddDtoCreator
{
    public static string CreateDto(Entity entity, string layer)
    {
        return $@"
using System.ComponentModel.DataAnnotations;
namespace Global;
public class Add{entity.Name}{layer}Dto
{{
    {String.Join("\n\t", entity.Props
.Where(x => !(x.PK || x.Identity) && x.Name != "PasswordHash"
&& AppContext.Get().AllowedValues.Contains(x.Type))
.Select(x =>
{
    string prop = "";
    if (x.IsRequired || (x.PK && !x.Identity))
        prop += $"[Required]\n";
    if (x.HasMaxLength.HasValue)
        prop += $"\t[StringLength({x.HasMaxLength.Value})]\n";
    prop += $"\tpublic {x.Type} {x.Name} {{ get; set; }}";
    return prop;
}))}
    [Required]
    public string {(layer == "Repository" ? "PasswordHash" : "Password")} {{ get; set; }}
}}";

    }
}