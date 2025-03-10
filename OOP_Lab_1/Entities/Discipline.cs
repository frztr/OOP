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
            if (value != lecturer)
            {
                lecturer = value;
            }
            if (!value.ReadingDisciplines.Contains(this))
            {
                value.ReadingDisciplines.Add(this);
            }            
        }
    }

    private Course course = null;
    public Course Course
    {
        get => course;
        set
        {
            if (value != course)
            {
                course = value;
            }
            if (!course.Disciplines.Contains(this))
            {
                course.Disciplines.Add(this);
            }            
        }
    }

    public Discipline(string name, string description)
    {
        Name = name;
        Description = description;
    }
    //5. Метод добавления новой дисциплины.
    public static Guid AddNew(string name, string description)
    {
        Discipline d = new Discipline(name, description);
        GlobalStorage.GetList<Discipline>().Add(d);
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