
namespace Lab_1;

public class DisciplineContext : IContext<Discipline>
{
    public IEnumerable<Discipline> entities => new List<Discipline>();

    public string Name => "Дисциплины";

    public void Add()
    {
        throw new NotImplementedException();
    }

    public void Delete()
    {
        throw new NotImplementedException();
    }

    public void Update()
    {
        throw new NotImplementedException();
    }
}