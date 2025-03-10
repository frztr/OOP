using Newtonsoft.Json;

namespace Lab_1;
public class StudentRepository : AbstractRepository<Student>
{
    public StudentRepository(InitializationType type) : base(type)
    {
    }

    protected override string TableName => "Students";

    protected override object SerializeFunction(Student item) =>
    new
    {
        item.Age,
        Course = item.Course != null ? item.Course.Id : (Guid?)null,
        item.Group,
        item.Id,
        item.Lastname,
        item.Name,
        item.Patronymic
    };

    protected override Student DeserializeFunction(dynamic item)
    {
        Course c = GlobalStorage.GetStorage().GetList<Course>().FirstOrDefault(x => x.Id == Guid.Parse((string)item.Course));
        Student student = new Student(
            (string)item.Name,
            (string)item.Lastname,
            (int)item.Age,
            (string)item.Patronymic,
            (string)item.Group,
            c)
        { Id = Guid.Parse((string)item.Id) };
        return student;
    }

    protected override void InitHardcode()
    {
        var courses = GlobalStorage.GetStorage().GetList<Course>();
        Course c1 = courses.FirstOrDefault(x => x.CourseNumber == 1);
        Course c2 = courses.FirstOrDefault(x => x.CourseNumber == 2);
        Course c3 = courses.FirstOrDefault(x => x.CourseNumber == 3);
        Course c4 = courses.FirstOrDefault(x => x.CourseNumber == 4);
        list.AddRange(new List<Student>(){
        new Student("Егор","Иванов",18,"Дмитриевич","ТСО-105Б-22",c1),
        new Student("Иван","Петров",19,"Данилович","ТСО-205Б-22",c2),
        new Student("Александр","Данилов",20,"Егорович","ТСО-305Б-22",c3),
        new Student("Дмитрий","Артёмов",21,"Иванович","ТСО-405Б-22",c4),
        new Student("Василий","Ильин",18,"Петрович","ТСО-105Б-22",c1),
        new Student("Петр","Иванов",19,"Александрович","ТСО-205Б-22",c2),
        new Student("Степан","Александров",20,"Ильич","ТСО-305Б-22",c3),
        new Student("Даниил","Васильев",21,"Алексеевич","ТСО-405Б-22",c4),
        new Student("Артём","Егоров",18,"Артёмович","ТСО-105Б-22",c1),
        new Student("Иван","Степанов",19,"Васильевич","ТСО-205Б-22",c2)
        });
    }
}