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
        Courses = new List<Course>();
        Disciplines = new List<Discipline>();
        Lecturers = new List<Lecturer>();
        Students = new List<Student>();
    }

    public GlobalStorage get()
    {
        if (storage == null)
            storage = new GlobalStorage();
        return storage;
    }
}