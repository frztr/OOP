namespace Lab_1;
//Класс Lecturer
//Описывает преподавателя. Данный класс является производным от класса Person
//1. Свойство Идентификатор наследует от Person
public class Lecturer : Person, IEntity
{
    //2. Свойство Ученое звание 
    public string Grade { get; set; }

    //3. Список преподаваемых дисциплин
    public List<Discipline> ReadingDisciplines { get; set; } = new List<Discipline>();

    public static List<Lecturer> Entities = new List<Lecturer>();
    private Lecturer(string name, string lastname, int age, string patronymic, string grade) : base(name, lastname, age, patronymic)
    {
        Grade = grade;
    }
    //4. Метод вывода информации о преподавателе (ФИО, список дисциплин и т.п.)
    public void DisplayInfo()
    {
        Console.WriteLine("Преподаватель:");
        base.DisplayInfo();
        Console.WriteLine($@"Учёное звание: {Grade}");
        Console.WriteLine($@"Список дисциплин:");
        ReadingDisciplines.ForEach(item =>
        {
            item.DisplayInfo();
        });
    }

    //5. Метод добавления нового преподавателя.
    public static Guid AddNew(string name, string lastname, int age, string patronymic, string grade)
    {
        Lecturer lecturer = new Lecturer(name, lastname, age, patronymic, grade);
        Entities.Add(lecturer);
        return lecturer.Id;
    }

    //6. Метод изменения данных преподавателя
    public void EditData(string name, string lastname, string patronymic, int? age, string Grade)
    {
        if (!String.IsNullOrEmpty(name)) Name = name;
        if (!String.IsNullOrEmpty(lastname)) Lastname = lastname;
        if (!String.IsNullOrEmpty(patronymic)) Patronymic = patronymic;
        if (age.HasValue) Age = age.Value;
    }
}