namespace Lab_1;

//Класс Student
//Описывает студента. Данный класс является производным от класса Person
//1. Свойство Идентификатор наследует от Person
public class Student : Person, IEntity
{
    public Student(string name, string lastname, int age, string patronymic, string group, Course course) : base(name, lastname, age, patronymic)
    {
        Course = course;
        Group = group;
    }
    //2. Свойство Номер группы
    public string Group { get; set; }
    //3. Свойство Курса
    public Course Course
    {get; set;}

    //4. Метод добавления нового студента
    public static Guid AddNew(string name, string lastname, int age, string patronymic, string group, Course course)
    {
        Student st = new Student(name, lastname, age, patronymic, group, course);
        GlobalStorage.GetStorage().GetList<Student>().Add(st);
        return st.Id;
    }
    //5. Метод обновления данных о студенте
    public void EditData(string name, string lastname, int? age, string patronymic, string group, Course course)
    {
        if (!String.IsNullOrEmpty(name)) Name = name;
        if (!String.IsNullOrEmpty(lastname)) Lastname = lastname;
        if (age.HasValue) Age = age.Value;
        if (!String.IsNullOrEmpty(patronymic)) Patronymic = patronymic;
        if (!String.IsNullOrEmpty(group)) Group = group;
        if (course != null) Course = course;
    }
    //6. Метод вывода информации о студенте
    public void DisplayInfo()
    {
        Console.WriteLine("Студент:");
        base.DisplayInfo();
        Course.DisplayInfo();
        Console.WriteLine($@"Группа: {Group}");
    }

}