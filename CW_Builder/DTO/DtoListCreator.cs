public class DtoListCreator
{
    public static string CreateDto(Entity entity)
    {
        return $@"
namespace Global;
public class {entity.Name}ListDto
{{
    public IEnumerable<{entity.Name}Dto> items {{ get; set; }}
}}";

    }
}