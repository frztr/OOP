namespace Lab_1;

public class Student : Person
{
    private Student(string name, string lastname, int age, string patronymic) : base(name, lastname, age, patronymic)
    {
    }

    public string Group { get; set; }

    public Course Course { get; set; }

    public static Student CreateStudent(string name, string lastname, int age, string patronymic, string group, Course course)
    {
        Student st = new Student(name, lastname, age, patronymic);
        st.Course = course;
        st.Group = group;
        return st;
    }

    public void EditData(string name, string lastname, int? age, string patronymic, string group, Course course)
    {
        if (!String.IsNullOrEmpty(name)) Name = name;
        if (!String.IsNullOrEmpty(lastname)) Lastname = lastname;
        if (!age.HasValue) Age = age.Value;
        if (!String.IsNullOrEmpty(patronymic)) Patronymic = patronymic;
        if (!String.IsNullOrEmpty(group)) Group = group;
        if (course != null) Course = course;
    }

    public void DisplayInfo(){
        Console.WriteLine($@"Студент: {Lastname} {Name} {Patronymic}. Курс: {Course.CourseNumber}. Группа: {Group}");
    }

}