
namespace Lab_1;

public class LecturerContext : IContext<Lecturer>
{
    public IEnumerable<Lecturer> entities => new List<Lecturer>();

    public string Name => "Преподаватели";

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
