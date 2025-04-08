public class UserUpdateDtoCreator
{
    public static string CreateDto(Entity entity, string layer)
    {
        return $@"
namespace Global;
public class Update{entity.Name}{layer}Dto
{{
    public {entity.Props.FirstOrDefault(x=>x.Name == "Id").Type} Id {{ get; set; }}
    {String.Join("\n\t", entity.Props
.Where(x => x.Name != "Id" && AppContext.Get().AllowedValues.Contains(x.Type) && x.Name != "PasswordHash")
.Select(x => $"public {x.Type}? {x.Name} {{ get; set; }}"))}
    public string {(layer == "Repository" ? "PasswordHash" : "Password")} {{ get; set; }}
}}";
    }
}