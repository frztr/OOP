using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lab_1;

public enum InitializationType
{
    Hardcode,
    Json
}

public abstract class AbstractRepository<T>
{
    protected abstract string TableName { get; }

    public List<T> list { get; } = new List<T>();
    protected abstract object SerializeFunction(T item);
    protected abstract T DeserializeFunction(dynamic item);

    private InitializationType type;
    public AbstractRepository(InitializationType type)
    {
        Init();
    }

    public async Task Init(){
        switch (type)
        {
            case InitializationType.Hardcode:
                InitHardcode();
                break;
            case InitializationType.Json:
                await InitFromJson();
                break;
        }
    }

    protected abstract void InitHardcode();

    protected async Task InitFromJson()
    {
        string data = await File.ReadAllTextAsync($@"./JsonStorage/{TableName}.json");
        list.AddRange(JsonConvert.DeserializeObject<dynamic[]>(data).ToList().Select(DeserializeFunction));
    }

    public async Task SaveChanges()
    {
        string data = JsonConvert.SerializeObject(list.Select(SerializeFunction));
        await File.WriteAllTextAsync($@"./JsonStorage/{TableName}.json", data);
    }


}