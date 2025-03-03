using Lab_1;

public class StudentContext : IContext<Student>
{
    public string Name => "Студенты";

    public IEnumerable<Student> entities => new List<Student>();

    public void Add()
    {
        Console.WriteLine("Добавление студента");
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