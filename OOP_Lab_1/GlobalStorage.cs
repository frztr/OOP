using Lab_1;

public class GlobalStorage
{

    private static GlobalStorage storage;
    public List<Course> Courses { get; set; }
    public List<Discipline> Disciplines { get; set; }
    public List<Lecturer> Lecturers { get; set; }
    public List<Student> Students { get; set; }
    private GlobalStorage()
    {
        Courses = new List<Course>(){
            new Course(1),
            new Course(2),
            new Course(3),
            new Course(4)
        };
        Disciplines = new List<Discipline>();
        Lecturers = new List<Lecturer>();
        Students = new List<Student>();
    }

    public static List<T> GetList<T>()
    {
        if (storage == null)
            storage = new GlobalStorage();
        object list = null;
        switch (typeof(T).Name.ToString())
        {
            case "Student":
                list = (object)storage.Students;
                break;
            case "Course":
                list = (object)storage.Courses;
                break;
            case "Lecturer":
                list = (object)storage.Lecturers;
                break;
            case "Discipline":
                list = (object)storage.Disciplines;
                break;
        }

        if (list != null)
        {
            return (List<T>)list;
        }

        return null;
    }
}