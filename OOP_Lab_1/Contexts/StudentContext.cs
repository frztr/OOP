
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Lab_1;

public class StudentContext : AbstractContext<Student>
{
    protected override string Name => "Студенты";
    protected override string SearchCriteria(Student item) => $@"{item.Name}{item.Lastname}{item.Patronymic}{item.Age}{item.Group}{item.Course}";
    protected override void AdditionalMenu()
    {
        Console.WriteLine($@"5. Просмотр информации о студенте");
    }

    protected override bool AdditionalOptions(int selection)
    {
        switch (selection)
        {
            case 5:
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
            c = ReadValueDialog<Course>("Номер курса", false);
        }
        while (group == null)
        {
            group = ReadValueDialog<string?>("Группа", false);
        }
        while (name == null)
        {
            name = ReadValueDialog<string?>("Имя", false);
        }
        while (lastname == null)
        {
            lastname = ReadValueDialog<string?>("Фамилия", false);
        }
        patronymic = ReadValueDialog<string?>("Отчество");
        while (age == null)
        {
            age = ReadValueDialog<int?>("Возраст", false);
        }
        Guid guid = Student.AddNew(name, lastname, age.Value, patronymic, group, c);
        Console.WriteLine($@"Студент создан с идентификатором {guid}");
        GlobalStorage.GetStorage().SaveChanges();
    }



    protected override void Update()
    {
        Console.WriteLine("Обновление студента");
        Student entity = GetByIdDialog();
        if (entity == null) return;
        entity.EditData(
            ReadValueDialog<string>("Имя"),
            ReadValueDialog<string>("Фамилия"),
            ReadValueDialog<int?>("Возраст"),
            ReadValueDialog<string>("Отчество"),
            ReadValueDialog<string>("Группа"),
            ReadValueDialog<Course>("Номер курса")
        );
        GlobalStorage.GetStorage().SaveChanges();
    }

    void ShowEntityInfo()
    {
        Console.WriteLine("Просмотр данных студента");
        Student entity = null!;
        do
        {
            entity = GetByIdDialog();
        }
        while (entity == null);
        entity.DisplayInfo();
    }
}