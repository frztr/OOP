
namespace Lab_1;

public class DisciplineContext : AbstractContext<Discipline>
{
    protected override string Name => "Дисциплины";

    protected override string SearchCriteria(Discipline item) => $@"{item.Name}{item.Description}";
    protected override void AdditionalMenu()
    {
        Console.WriteLine($@"5. Прикрепить дисциплину к преподавателю        
6. Прикрепить дисциплину к курсу");
    }

    protected override bool AdditionalOptions(int selection)
    {
        switch (selection)
        {
            case 5:
                AddDisciplineToLecturer();
                return true;
            case 6:
                AddDisciplineToCourse();
                return true;
            default:
                return false;
        }
    }

    protected override void Add()
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
    }

    protected override void Update()
    {
        Console.WriteLine("Обновление дисциплины");
        Discipline entity = GetByIdDialog();
        if (entity == null) return;

        entity.EditData(
            ReadValueDialog<string>("Название дисциплины"),
            ReadValueDialog<string>("Краткое описание дисциплины")
        );
    }

    void AddDisciplineToLecturer()
    {
        Discipline entity = GetByIdDialog();
        if (entity == null) return;
        Lecturer lecturer = new LecturerContext().GetByIdDialog();
        if (lecturer == null) return;
        entity.Lecturer = lecturer;
    }

    void AddDisciplineToCourse()
    {
        Discipline entity = GetByIdDialog();
        if (entity == null) return;
        int? courseNumber = ReadValueDialog<int?>("номер курса");
        Course course = GlobalStorage.GetList<Course>().FirstOrDefault(x => x.CourseNumber == courseNumber.Value);
        if (course == null)
        {
            Console.WriteLine("Курс не найден");
            return;
        }
        entity.Course = course;
    }

    protected override Discipline Delete()
    {
        var entity = base.Delete();
        if (entity != null)
        {
            if (entity.Lecturer != null)
            {
                entity.Lecturer.ReadingDisciplines.Remove(entity);
            }
            if (entity.Course != null)
            {
                entity.Course.Disciplines.Remove(entity);
            }
        }
        return entity;
    }


}