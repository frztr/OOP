using Newtonsoft.Json;

public interface IDto { }

public static class Casting
{
    public static T Cast<T>(this IDto obj)
    {
        var serializedParent = JsonConvert.SerializeObject(obj,Formatting.Indented,
        new JsonSerializerSettings
        {
            PreserveReferencesHandling = PreserveReferencesHandling.Objects
        });
        T c = JsonConvert.DeserializeObject<T>(serializedParent);
        return c;
    }

    public static T Cast<T>(this IEntity obj)
    {
        var serializedParent = JsonConvert.SerializeObject(obj, Formatting.Indented,
        new JsonSerializerSettings
        {
            PreserveReferencesHandling = PreserveReferencesHandling.Objects
        });
        Console.WriteLine(serializedParent);
        T c = JsonConvert.DeserializeObject<T>(serializedParent);
        return c;
    }
}