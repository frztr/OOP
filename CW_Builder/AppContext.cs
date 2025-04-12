public class AppContext
{
    private static AppContext context;
    private AppContext(string projectPath)
    {
        this.ProjectPath = projectPath;
    }

    public static void Init(string[] args)
    {
        string defaultName = "../Project";

        if (args.Length == 0 || String.IsNullOrEmpty(args[0]))
        {
            Directory.CreateDirectory("../Project");
            Console.WriteLine("Папка проекта не была задана в качестве параметра программы, поэтому была создана папка ../Project.");
        }
        else
        {
            defaultName = args[0];
        }
        context = new AppContext(defaultName);
    }
    public static AppContext Get()
    {
        return context;
    }
    public string[] AllowedValues { get; } = ["string", "short", "int", "long", "DateTime", "decimal",
    "string?", "short?", "int?", "long?", "DateTime?", "decimal?"];
    public string ProjectPath { get; }
}