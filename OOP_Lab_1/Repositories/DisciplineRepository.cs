using Lab_1;

public class DisciplineRepository : AbstractRepository<Discipline>
{
    public DisciplineRepository(InitializationType type) : base(type)
    {
    }

    protected override string TableName => "Disciplines";

    protected override object SerializeFunction(Discipline item) => new
    {
        item.Id,
        item.Name,
        item.Description,
        Lecturer = (item.Lecturer != null) ? item.Lecturer.Id : (Guid?)null,
        Course = (item.Course != null) ? item.Course.Id : (Guid?)null
    };

    protected override Discipline DeserializeFunction(dynamic item)
    {
        Discipline d = new Discipline(
            (string)item.Name,
            (string)item.Description
        )
        { Id = Guid.Parse((string)item.Id) };
        if (item.Course != null)
        {
            d.Course = GlobalStorage.GetStorage().GetList<Course>()
            .FirstOrDefault(x => x.Id == Guid.Parse((string)item.Course));
        }
        if (item.Lecturer != null)
        {
            d.Lecturer = GlobalStorage.GetStorage().GetList<Lecturer>().FirstOrDefault(x => x.Id == Guid.Parse((string)item.Lecturer));
        }
        return d;
    }

    protected override void InitHardcode()
    {
        list.AddRange(new List<Discipline>(){
        new Discipline("Объектно-ориентированное программирование", ""),
        new Discipline("Сети и телекоммуникации", ""),
        new Discipline("Экономика отрасли", ""),
        new Discipline("Иностранный язык", ""),
        new Discipline("Авиационные материалы и технологии", ""),
        new Discipline("Основы менеджмента", ""),
        new Discipline("Базы данных", ""),
        new Discipline("Математический анализ", ""),
        new Discipline("Компьютерная графика", ""),
        new Discipline("Информатика", "")});
    }
}