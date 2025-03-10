using Lab_1;
using Newtonsoft.Json.Linq;

public class CourseRepository : AbstractRepository<Course>
{
    public CourseRepository(InitializationType type) : base(type)
    {
    }

    protected override string TableName => "Courses";

    protected override object SerializeFunction(Course item) => new
    {
        item.Id,
        item.CourseNumber,
        Disciplines = item.Disciplines.Select(x => x.Id)
    };

    protected override Course DeserializeFunction(dynamic item)
    {
        Course c = new Course((int)item.CourseNumber)
        {
            Id = Guid.Parse((string)item.Id)
        };
        if (item.Disciplines != null)
        {
            c.Disciplines = GlobalStorage.GetStorage().GetList<Discipline>()
            .Where(x => ((JArray)item.ReadingDisciplines).ToObject<List<string>>()
            .Select(y => Guid.Parse((string)y)).Contains(x.Id))
            .ToList();
            c.Disciplines.ForEach(x => x.Course = c);
        }

        return c;
    }

    protected override void InitHardcode()
    {
        Course c1 = new Course(1);
        Course c2 = new Course(2);
        Course c3 = new Course(3);
        Course c4 = new Course(4);
        list.AddRange(new List<Course>(){
            c1,c2,c3,c4
        });
    }
}