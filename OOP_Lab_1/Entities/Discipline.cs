namespace Lab_1;
//Класс Discipline
//Описывает дисциплину.

public class Discipline : IEntity
{
    //1. Свойство Идентификатор
    public Guid Id {get;} = Guid.NewGuid();
    //2. Свойство Название дисциплины
    public string Name { get; set; }
    //3. Свойство Краткое описание дисциплины
    public string Description { get; set; }

    private Lecturer lecturer = null;
    //4. Свойство Преподаватель
    public Lecturer Lecturer
    {
        get => lecturer;
        set
        {
            if (!value.ReadingDisciplines.Contains(this))
            {
                value.ReadingDisciplines.Add(this);
            }
            if (value != Lecturer)
            {
                lecturer = value;
            }
            
        }
    }

    private Course course = null;
    public Course Course
    {
        get => course;
        set
        {
            if (!course.Disciplines.Contains(this))
            {
                course.Disciplines.Add(this);
            }
            if (value != course)
            {
                course = value;
            }
            
        }
    }

    public static List<Discipline> Entities = new List<Discipline>();

    private Discipline(string name, string description)
    {
        Name = name;
        Description = description;
    }
    //5. Метод добавления новой дисциплины.
    public static Guid AddNew(string name, string description)
    {
        Discipline d = new Discipline(name, description);
        Entities.Add(d);
        return d.Id;
    }
    //6. Метод изменения данных дисциплины
    public void EditData(string name, string description)
    {
        if (!String.IsNullOrEmpty(name)) Name = name;
        if (!String.IsNullOrEmpty(description)) Description = description;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($@"Дисциплина:
Id:{Id} {Name}
{Description}");
        if (Course != null)
        {
            Console.WriteLine($@"Курс:");
            Course.DisplayInfo();
        }
    }
}