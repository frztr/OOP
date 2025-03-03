using Lab_1;

public class StudentContext : Context
{
    public override string Name => "Студенты";

    public override void Add()
    {
        Console.WriteLine("Добавление студента");
    }

    public override void Delete()
    {
        throw new NotImplementedException();
    }

    public override void Update()
    {
        throw new NotImplementedException();
    }
}