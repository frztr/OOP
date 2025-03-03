namespace Lab_1;

public class Person
{
    public Guid Id { get; set; } = new Guid();
    
    public string Name { get; set; }
    public string Lastname { get; set; }

    public string Patronymic { get; set; }

    public int Age {get;set;}

    public Person(string name, string lastname, int age,string patronymic)
    {
        Name = name;
        Lastname = lastname;
        Age = age;
        if(!String.IsNullOrEmpty(patronymic)) Patronymic = patronymic;
    }
}