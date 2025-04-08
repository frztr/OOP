public class UserLoginDtoCreator
{
    public static string CreateDto(Entity entity, string layer)
    {
        return $@"
namespace Global;
public class UserLogin{layer}Dto
{{
    public string Login {{get; set;}}
    public string {(layer == "Repository" ?"PasswordHash":"Password")} {{ get; set; }}
}}";
    }
}