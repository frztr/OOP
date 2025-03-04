namespace Lab_1;

public class StudentContext : IContext<Student>
{
    public string Name => "Студенты";

    public IEnumerable<Student> entities => new List<Student>();

    public void Add()
    {
        Console.WriteLine("Добавление студента");
        Console.WriteLine("Введите номер курса, название группы, имя, фамилию, возраст, отчество(опционально) через ';'");
        while (true)
        {
            string[] _params = Console.ReadLine().Split(";");
            if (_params.Length < 6)
            {
                Console.WriteLine("Параметров не может быть меньше 6");
                continue;
            }
            if (String.IsNullOrEmpty(_params[0]))
            {
                Console.WriteLine("Неверный формат ввода номера курса");
                continue;
            }
            if (String.IsNullOrEmpty(_params[1]))
            {
                Console.WriteLine("Неверный формат ввода названия группы");
                continue;
            }
            if (!int.TryParse(_params[2], out int age))
            {
                Console.WriteLine("Неверный формат ввода возраста");
                continue;
            }

            // Student st = Student.CreateNew(_params[0],_params[1],age,(_params.Length>3?_params[3]:null));
        }
        
    }

    void IContext<Student>.AdditionalMenu()
    {
        Console.WriteLine("4. Просмотр информации о студенте");
    }

    public void Delete()
    {
        throw new NotImplementedException();
    }

    public void Update()
    {
        throw new NotImplementedException();
    }
}