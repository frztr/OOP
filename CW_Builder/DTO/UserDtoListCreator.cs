public class UserDtoListCreator
{
    public static string CreateDto(Entity entity, string layer)
    {
        return $@"
namespace Global;
public class {entity.Name}List{layer}Dto
{{
    public IEnumerable<{entity.Name}{layer}Dto> Items {{ get; set; }}
}}";

    }
}