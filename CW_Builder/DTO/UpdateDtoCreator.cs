public class UpdateDtoCreator
{
    public static string CreateDto(Entity entity)
    {
        return $@"
namespace Global;
public class Update{entity.Name}Dto
{{
    public {entity.Props.FirstOrDefault(x=>x.Name == "Id").Type} Id {{ get; set; }}
    {String.Join("\n\t", entity.Props
.Where(x => x.Name != "Id" && AppContext.Get().AllowedValues.Contains(x.Type))
.Select(x => $"public {x.Type}? {x.Name} {{ get; set; }}"))}
}}";
    }
}