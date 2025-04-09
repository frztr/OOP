public class AppConfigCsCreator{
    private static string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
    public static string Create(){
        return $@"public class AppConfig{{
    public readonly static string KEY = ""{new string(Enumerable.Repeat(chars, 32)
        .Select(s => s[new Random().Next(s.Length)]).ToArray())}"";
    public readonly static string ISSUER = ""{AppContext.Get().ProjectPath.Split("/").LastOrDefault()}"";
    public readonly static string AUDIENCE = ""{AppContext.Get().ProjectPath.Split("/").LastOrDefault()}Client"";
}}";
    }
}