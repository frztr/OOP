
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Lab_1;

public class StudentContext : AbstractContext<Student>
{
    protected override string Name => "Студенты";

    protected override void AdditionalMenu()
    {
        Console.WriteLine("4. Просмотр информации о студенте");
    }

    protected override bool AdditionalOptions(int selection)
    {
        switch (selection)
        {
            case 4:
                ShowEntityInfo();
                return true;
            default:
                return false;
        }
    }

    protected override void Add()
    {
        Console.WriteLine("Добавление студента");
        int? age = null;
        string? group = null;
        string? name = null;
        string? lastname = null;
        string? patronymic = null;
        Course c = null;

        while (c == null)
        {
            c = ReadDialog<Course>("course", false);
        }
        while (group == null)
        {
            group = ReadDialog<string?>("group", false);
        }
        while (name == null)
        {
            name = ReadDialog<string?>("name", false);
        }
        while (lastname == null)
        {
            lastname = ReadDialog<string?>("lastname", false);
        }
        patronymic = ReadDialog<string?>("patronymic");
        while (age == null)
        {
            age = ReadDialog<int?>("age", false);
        }
        Student st = Student.CreateNew(name, lastname, age.Value, patronymic, group, c);
        Entities.Add(st);
        Console.WriteLine($@"Студент создан с идентификатором {st.Id}");
    }



    protected override void Update()
    {
        Console.WriteLine("Обновление студента");
        Student entity = null!;
        Guid guid = ReadDialog<Guid>("идентификатор");
        entity = Entities.FirstOrDefault(x => x.Id == guid)!;
        if (entity == null)
        {
            Console.WriteLine("Запись с данным идентификатором не найдена");
            return;
        }

        entity.Course = ReadDialog<Course>("course") ?? entity.Course;
        entity.Group = ReadDialog<string>("group") ?? entity.Group;
        entity.Name = ReadDialog<string>("name") ?? entity.Name;
        entity.Lastname = ReadDialog<string>("lastname") ?? entity.Lastname;
        entity.Age = ReadDialog<int?>("age") ?? entity.Age;
        entity.Patronymic = ReadDialog<string>("patronymic") ?? entity.Patronymic;
        return;
    }

    void ShowEntityInfo()
    {
        Console.WriteLine("Просмотр данных студента");
        Console.WriteLine("Введите идентификатор студента");
        Student entity = null!;
        while (entity == null)
        {
            Guid id = ReadDialog<Guid>("идентификатор");
            entity = Entities.FirstOrDefault(x => x.Id == id)!;
            entity.DisplayInfo();
            if (entity == null)
            {
                Console.WriteLine("Запись с данным идентификатором не найдена");
            }
        }
    }
}