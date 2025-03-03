namespace Lab_1;
public class Lecturer : Person
{
    public string Grade { get; set; }

    public List<Discipline> readingDisciplines { get; set; } = new List<Discipline>();

    private Lecturer(string name, string lastname, int age, string patronymic) : base(name, lastname, age, patronymic)
    {
    }

    public void DisplayInfo()
    {
        Console.WriteLine($@"ФИО: {Lastname} {Name} {Patronymic}");
        Console.WriteLine($@"Список дисциплин:");
        readingDisciplines.Select((d, i) => new { d, i }).ToList().ForEach(item =>
        {
            Console.WriteLine($@"{item.i + 1}.{item.d.Name}({item.d.Abbr})");
        });
    }

    public static Lecturer CreateLecturer(string name, string lastname, int age, string patronymic, string grade, List<Discipline> readingDisciplines)
    {
        Lecturer lecturer = new Lecturer(name, lastname, age, patronymic);
        lecturer.Grade = grade;
        if (readingDisciplines != null) lecturer.readingDisciplines = readingDisciplines;
        return lecturer;
    }

    public void EditData(string name, string lastname, string patronymic, int? age, string Grade, List<Discipline> disciplines)
    {
        if (!String.IsNullOrEmpty(name)) Name = name;
        if (!String.IsNullOrEmpty(lastname)) Lastname = lastname;
        if (!String.IsNullOrEmpty(patronymic)) Patronymic = patronymic;
        if (age.HasValue) Age = age.Value;
        if (disciplines != null) readingDisciplines = disciplines;
    }
}