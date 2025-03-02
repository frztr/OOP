namespace OOP_1;
public class Student
{
    public Guid GUID {get;} = Guid.NewGuid();
    public string Name { get; set; } = "Test";
    public string Lastname { get; set; } = "Test";
    public string Patronymic { get; set; } = "Test";
    public int Age { get; set; } = 10;
    public string Group { get; set; } = "Test";

    public Student(
        string name,
        string lastname,
        string patronymic,
        int age,
        string group
    )
    {
        this.Name = name;
        this.Lastname = lastname;
        this.Patronymic = patronymic;
        this.Age = age;
        this.Group = group;
    }

    public void DisplayData()
    {
        Console.WriteLine($@"Id: {GUID}");
        Console.WriteLine($@"Имя: {Name}");
        Console.WriteLine($@"Фамилия: {Lastname}");
        Console.WriteLine($@"Отчество: {Patronymic}");
        Console.WriteLine($@"Возраст: {Age}");
        Console.WriteLine($@"Группа: {Group}");
    }
}