using Lab_1;

public class GlobalStorage
{

    private static GlobalStorage storage;
    private List<Course> courses;
    private List<Discipline> disciplines;
    private List<Lecturer> lecturers;
    private List<Student> students;
    private GlobalStorage()
    {
        courses = new List<Course>(){
            new Course(1),
            new Course(2),
            new Course(3),
            new Course(4)
        };
        disciplines = new List<Discipline>();
        lecturers = new List<Lecturer>();
        students = new List<Student>();
    }

    public static List<T> GetList<T>()
    {
        if (storage == null)
            storage = new GlobalStorage();
        object list = null;
        switch (typeof(T).Name.ToString())
        {
            case "Student":
                list = (object)storage.students;
                break;
            case "Course":
                list = (object)storage.courses;
                break;
            case "Lecturer":
                list = (object)storage.lecturers;
                break;
            case "Discipline":
                list = (object)storage.disciplines;
                break;
        }

        if (list != null)
        {
            return (List<T>)list;
        }

        return null;
    }
}