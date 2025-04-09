public class AppSettingsCreator
{
    public static string Create()
    {
        return @"{
  ""Logging"": {
    ""LogLevel"": {
      ""Default"": ""Trace"",
      ""Microsoft.AspNetCore"": ""Warning""
    }
  }
}";
    }
}