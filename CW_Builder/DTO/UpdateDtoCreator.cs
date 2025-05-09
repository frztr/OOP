public class UpdateDtoCreator
{
    public static string CreateDto(Entity entity, string layer)
    {
        var pk = entity.Props.FirstOrDefault(x => x.PK);
        string prop = "";
        if (pk.HasMaxLength.HasValue)
            prop += $"\t[StringLength({pk.HasMaxLength.Value})]\n";
        prop += $"\tpublic {pk.Type} {pk.Name} {{ get; set; }}";
        return $@"
using System.ComponentModel.DataAnnotations;
namespace Global;
public class Update{entity.Name}{layer}Dto
{{
    [Required]
{prop}
{String.Join("\n", entity.Props
.Where(x => !(x.PK) && !(x.Identity)
&& AppContext.Get().AllowedValues.Contains(x.Type))
.Select(x =>
{
    string prop = "";
    if (x.HasMaxLength.HasValue)
        prop += $"\t[StringLength({x.HasMaxLength.Value})]\n";
    prop += $"\tpublic {(x.Type.Contains("?")?x.Type:$"{x.Type}?")} {x.Name} {{ get; set; }}";
    return prop;
}))}
}}";
    }
}