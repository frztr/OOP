public class AddDtoCreator
{
    public static string CreateDto(Entity entity)
    {
        return $@"
namespace Global;
public class Add{entity.Name}Dto
{{
{String.Join("\n\t", entity.Props
.Where(x => x.Name != "Id" && AppContext.Get().AllowedValues.Contains(x.Type))
.Select(x => $"public {x.Type} {x.Name} {{ get; set; }}"))}
}}";

    }
}