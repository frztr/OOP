public class DtoCreator
{
    public static string CreateDto(Entity entity)
    {
        return $@"
namespace Global;
public class {entity.Name}Dto
{{
    {String.Join("\n\t", entity.Props
.Where(x => AppContext.Get().AllowedValues.Contains(x.Type))
.Select(x => $"public {x.Type} {x.Name} {{ get; set; }}"))}
}}";
    }
}