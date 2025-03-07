namespace Lab_1;

//Класс Course
//В этом классе должны содержаться:
public class Course : IEntity
{
    //1. Свойство Идентификатор
    public Guid Id { get; set; } = Guid.NewGuid();
    //2. Свойство Номера курса
    public int CourseNumber { get; set; }

    //3. Список Дисциплин этого курса
    public List<Discipline> Disciplines = new List<Discipline>();

    public static List<Course> Entities = new List<Course>();

    public Course(int courseNumber)
    {
        CourseNumber = courseNumber;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($@"Курс: Id:{Id} Номер: {CourseNumber}");
    }
}