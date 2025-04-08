public class UserLoginDtoCreator
{
    public static string CreateDto(Entity entity, string layer)
    {
        return $@"
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UserLogin{layer}Dto
{{
    [Required]
    [StringLength(32)]
    public string Login {{get; set;}}
    [Required]
    public string {(layer == "Repository" ?"PasswordHash":"Password")} {{ get; set; }}
}}";
    }
}