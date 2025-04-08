public class UserLoginResultDtoCreator
{
    public static string CreateDto(Entity entity, string layer)
    {
        if(layer == "Repository"){
            return $@"
namespace Global;
public class UserLoginResult{layer}Dto
{{
    {String.Join("\n\t", entity.Props
.Where(x => AppContext.Get().AllowedValues.Contains(x.Type) 
&& x.Name != "PasswordHash" 
&& x.Name != "RoleId")
.Select(x => $"public {x.Type} {x.Name} {{ get; set; }}"))}

    public string RoleName {{ get;set; }}
}}";
        }else{
            return $@"
namespace Global;
public class UserLoginResult{layer}Dto
{{
    public string Token {{ get;set; }}
}}";
        }
        
    }
}
