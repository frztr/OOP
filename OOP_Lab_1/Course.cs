namespace Lab_1;

public class Course{
    public Guid Id {get;set;} = new Guid();
    public int CourseNumber {get;set;}

    public List<Discipline> disciplines = new List<Discipline>();

    public Course(int courseNumber){
        CourseNumber = courseNumber;
    }
}