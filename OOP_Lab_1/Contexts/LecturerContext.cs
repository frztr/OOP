
namespace Lab_1;

public class LecturerContext : AbstractContext<Lecturer>
{
    protected override string Name => "Преподаватели";
    protected override string SearchCriteria(Lecturer item) => $@"{item.Name}{item.Lastname}{item.Patronymic}{item.Age}{item.Grade}";
    protected override void AdditionalMenu()
    {
        Console.WriteLine("5. Просмотр информации о преподавателе");
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
        string? name = null;
        string? lastname = null;
        string? patronymic = null;
        int? age = null;
        string? grade = null;

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
        while (grade == null)
        {
            grade = ReadValueDialog<string?>("Ученое звание", false);
        }
        Guid guid = Lecturer.AddNew(name, lastname, age.Value, patronymic, grade);
        Console.WriteLine($@"Преподаватель создан с идентификатором {guid}");
        GlobalStorage.GetStorage().SaveChanges();
    }

    protected override void Update()
    {
        Console.WriteLine("Обновление преподавателя");
        Lecturer entity = null!;
        Guid guid = ReadValueDialog<Guid>("идентификатор");
        entity = Entities.FirstOrDefault(x => x.Id == guid)!;
        if (entity == null)
        {
            Console.WriteLine("Запись с данным идентификатором не найдена");
            return;
        }
        entity.EditData(
            ReadValueDialog<string>("Имя"),
            ReadValueDialog<string>("Фамилия"),
            ReadValueDialog<string>("Отчество"),
            ReadValueDialog<int?>("Возраст"),
            ReadValueDialog<string>("Учёное звание")
        );
        GlobalStorage.GetStorage().SaveChanges();
    }

    void ShowEntityInfo()
    {
        Console.WriteLine("Просмотр данных преподавателя");
        Lecturer entity = null!;
        do
        {
            entity = GetByIdDialog();
        }
        while (entity == null);
        entity.DisplayInfo();
    }


}
