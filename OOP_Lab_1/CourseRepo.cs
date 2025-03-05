using Lab_1;

public class CourseRepo
{
    private CourseRepo()
    {
        this.courses.AddRange(new List<Course>() {
            new Course(1),
            new Course(2),
            new Course(3),
            new Course(4)
            });
    }

    private static CourseRepo instance;

    public static CourseRepo getCourseRepo()
    {
        if (instance == null)
        {
            instance = new CourseRepo();
        }
        return instance;
    }

    public List<Course> courses = new List<Course>();
}