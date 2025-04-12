using System.Text.RegularExpressions;

public class SQLParser{
    public static void Parse(string text){
        var id_regex = "[]{1}";
        string tablerow = @"([\w]+){1} ([\w]+(\([0-9]+\))*){1}( [\w]+)";
        string script_regex = $@"create table ([\w]+){{1}}\s*\([\W]*{tablerow}";
        var tables = Regex.Matches(text, script_regex);
        // var tables = Regex.Matches(text, $@"create table\([\w]+ ([\w]+([\(][0-9][\)])*){1}( [\w])*");
        foreach(var table in tables){
            Console.WriteLine(table);
        }
    }
}