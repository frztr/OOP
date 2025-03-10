
namespace Lab_1;

public class DisciplineContext : AbstractContext<Discipline>
{
    protected override string Name => "Дисциплины";

    protected override string SearchCriteria(Discipline item) => $@"{item.Name}{item.Description}";
    protected override Task AdditionalMenu()
    {
        Console.WriteLine($@"5. Прикрепить дисциплину к преподавателю        
6. Прикрепить дисциплину к курсу");
        return Task.CompletedTask;
    }

    protected override async Task<bool> AdditionalOptions(int selection)
    {
        switch (selection)
        {
            case 5:
                await AddDisciplineToLecturer();
                return true;
            case 6:
                await AddDisciplineToCourse();
                return true;
            default:
                return false;
        }
    }

    protected override async Task Add()
    {
        Console.WriteLine("Добавление дисциплины");
        string? name = null;
        string? description = null;
        while (name == null)
        {
            name = ReadValueDialog<string?>("Название дисциплины");
        }
        while (description == null)
        {
            description = ReadValueDialog<string?>("Краткое описание дисциплины");
        }
        Guid guid = Discipline.AddNew(name, description);
        Console.WriteLine($@"Дисциплина создана с идентификатором {guid}");
        await GlobalStorage.GetStorage().SaveChanges();
    }

    protected override async Task Update()
    {
        Console.WriteLine("Обновление дисциплины");
        Discipline entity = GetByIdDialog();
        if (entity == null) return;

        entity.EditData(
            ReadValueDialog<string>("Название дисциплины"),
            ReadValueDialog<string>("Краткое описание дисциплины")
        );
        await GlobalStorage.GetStorage().SaveChanges();
    }

    async Task AddDisciplineToLecturer()
    {
        Discipline entity = GetByIdDialog();
        if (entity == null) return;
        Lecturer lecturer = new LecturerContext().GetByIdDialog();
        if (lecturer == null) return;
        entity.Lecturer = lecturer;
        await GlobalStorage.GetStorage().SaveChanges();
    }

    async Task AddDisciplineToCourse()
    {
        Discipline entity = GetByIdDialog();
        if (entity == null) return;
        int? courseNumber = ReadValueDialog<int?>("номер курса");
        Course course = GlobalStorage.GetStorage().GetList<Course>().FirstOrDefault(x => x.CourseNumber == courseNumber.Value);
        if (course == null)
        {
            Console.WriteLine("Курс не найден");
            return;
        }
        entity.Course = course;
        await GlobalStorage.GetStorage().SaveChanges();
    }
}