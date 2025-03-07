namespace Lab_1;

//Класс Person 
//Описывает человека.
public class Person
{
    //1. Свойство Идентификатор
    public Guid Id { get; set; } = Guid.NewGuid();
    //2. Свойство Имени
    public string Name { get; set; }
    //3. Свойство Фамилии
    public string Lastname { get; set; }
    //4.Свойство Отчества (если имеется)
    public string Patronymic { get; set; }
    //5. Свойство Возраста
    public int Age { get; set; }

    public Person(string name, string lastname, int age, string patronymic)
    {
        Name = name;
        Lastname = lastname;
        Age = age;
        if (!String.IsNullOrEmpty(patronymic)) Patronymic = patronymic;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($@"Id:{Id} ФИО: {Lastname} {Name} {Patronymic} Возраст: {Age}");
    }
}