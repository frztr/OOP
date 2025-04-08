public class UserAddDtoCreator
{
    public static string CreateDto(Entity entity, string layer)
    {
        return $@"
namespace Global;
public class Add{entity.Name}{layer}Dto
{{
{String.Join("\n\t", entity.Props
.Where(x => x.Name != "Id" && AppContext.Get().AllowedValues.Contains(x.Type) && x.Name != "PasswordHash")
.Select(x => $"public {x.Type} {x.Name} {{ get; set; }}"))}
    public string {(layer == "Repository" ? "PasswordHash" : "Password")} {{ get; set; }}
}}";

    }
}