public class AppConfigCsCreator{
    private static string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
    public static string Create(){
        var name = AppContext.Get().ProjectPath.Split("/").LastOrDefault();
        if(name == "") 
            name = "App";
        return $@"
namespace Global;
public class AppConfig{{
    public readonly static string KEY = ""{new string(Enumerable.Repeat(chars, 32)
        .Select(s => s[new Random().Next(s.Length)]).ToArray())}"";
    public readonly static string ISSUER = ""{name}"";
    public readonly static string AUDIENCE = ""{name}Client"";
}}";
    }
}