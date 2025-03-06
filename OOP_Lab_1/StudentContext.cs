
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Lab_1;

public class StudentContext : IContext<Student>
{
    public string Name => "Студенты";


    void IContext<Student>.AdditionalMenu()
    {
        Console.WriteLine("4. Просмотр информации о студенте");
    }

    bool IContext<Student>.AdditionalOptions(int selection)
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

    public void Add()
    {
        Console.WriteLine("Добавление студента");
        var _this = (IContext<Student>)this;
        int? age = null;
        string? group = null;
        string? name = null;
        string? lastname = null;
        string? patronymic = null;
        Course c = null;

        while (c == null)
        {
            c = _this.ReadDialog<Course>("course", false);
        }
        while (group == null)
        {
            group = _this.ReadDialog<string?>("group", false);
        }
        while (name == null)
        {
            name = _this.ReadDialog<string?>("name", false);
        }
        while (lastname == null)
        {
            lastname = _this.ReadDialog<string?>("lastname", false);
        }
        patronymic = _this.ReadDialog<string?>("patronymic");
        while (age == null)
        {
            age = _this.ReadDialog<int?>("age", false);
        }
        Student st = Student.CreateNew(name, lastname, age.Value, patronymic, group, c);
        IContext<Student>.Entities = IContext<Student>.Entities.Union(new List<Student> { st });
        Console.WriteLine($@"Студент создан с идентификатором {st.Id}");
    }



    public void Update()
    {
        Console.WriteLine("Обновление студента");
        var _this = (IContext<Student>)this;
        Student entity = null!;
        Guid guid = _this.ReadDialog<Guid>("идентификатор");
        entity = IContext<Student>.Entities.FirstOrDefault(x => x.Id == guid)!;
        if (entity == null)
        {
            Console.WriteLine("Запись с данным идентификатором не найдена");
            return;
        }

        entity.Course = _this.ReadDialog<Course>("course") ?? entity.Course;
        entity.Group = _this.ReadDialog<string>("group") ?? entity.Group;
        entity.Name = _this.ReadDialog<string>("name") ?? entity.Name;
        entity.Lastname = _this.ReadDialog<string>("lastname") ?? entity.Lastname;
        entity.Age = _this.ReadDialog<int?>("age") ?? entity.Age;
        entity.Patronymic = _this.ReadDialog<string>("patronymic") ?? entity.Patronymic;
        return;
    }

    void ShowEntityInfo()
    {
        var _this = (IContext<Student>)this;
        Console.WriteLine("Просмотр данных студента");
        Console.WriteLine("Введите идентификатор студента");
        Student entity = null!;
        while (entity == null)
        {
            Guid id = _this.ReadDialog<Guid>("идентификатор");
            entity = IContext<Student>.Entities.FirstOrDefault(x => x.Id == id)!;
            entity.DisplayInfo();
            if (entity == null)
            {
                Console.WriteLine("Запись с данным идентификатором не найдена");
            }
        }
    }
}