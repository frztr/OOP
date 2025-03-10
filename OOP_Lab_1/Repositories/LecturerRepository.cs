using Lab_1;
using Newtonsoft.Json.Linq;

public class LecturerRepository : AbstractRepository<Lecturer>
{
    public LecturerRepository(InitializationType type) : base(type)
    {
    }

    protected override string TableName => "Lecturers";

    protected override object SerializeFunction(Lecturer item) => new
    {
        item.Id,
        item.Lastname,
        item.Name,
        item.Patronymic,
        item.Age,
        item.Grade,             
        ReadingDisciplines = item.ReadingDisciplines.Select(x => x.Id)
    };

    protected override Lecturer DeserializeFunction(dynamic item)
    {
        Lecturer l = new Lecturer(
            (string)item.Name,
            (string)item.Lastname,
            (int)item.Age,
            (string)item.Patronymic,
            (string)item.Grade)
        { Id = Guid.Parse((string)item.Id) };
        if (item.ReadingDisciplines != null)
        {
            l.ReadingDisciplines = GlobalStorage.GetStorage().GetList<Discipline>()
            .Where(x => ((JArray)item.ReadingDisciplines).ToObject<List<string>>()
            .Select(y => Guid.Parse(y)).Contains(x.Id))
            .ToList();
            l.ReadingDisciplines.ForEach(x => x.Lecturer = l);
        }
        return l;
    }

    protected override void InitHardcode()
    {
        list.AddRange(new List<Lecturer>(){
        new Lecturer("Борис", "Новиков", 31, "Борисович", "нет"),
        new Lecturer("Александр", "Челпанов", 46, "Витальевич", "доцент по кафедре \"Моделирования систем и информационных технологий\""),
        new Lecturer("Ольга", "Степнова", 56, "Викторовна", "доцент по кафедре \"Экономика и управление\""),
        new Lecturer("Ирина", "Старчикова", 60, "Юрьевна", "нет"),
        new Lecturer("Игорь ", "Мамонов", 65, "Михайлович", "Доцент по кафедре \"Прикладная математика\""),
        new Lecturer("Светлана", "Курашова", 41, "Александровна", "нет"),
        new Lecturer("Павел", "Антонов", 30, "Алексеевич", "нет"),
        new Lecturer("Елена", "Каратаева", 25, "Сергеевна", "нет"),
        new Lecturer("Людмила", "Еременская", 65, "Ивановна", "нет"),
        new Lecturer("Юлия", "Егорова", 67, "Борисовна", @"
Доцент по кафедре «Прикладная математика»
Профессор по кафедре «Материаловедение и пластическая деформация металлов»")
});
    }
}