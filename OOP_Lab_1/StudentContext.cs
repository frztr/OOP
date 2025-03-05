
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Lab_1;

public class StudentContext : IContext<Student>
{
    public string Name => "Студенты";

    private List<Student> entities = new List<Student>();

    public IEnumerable<Student> Entities => entities;

    public void Add()
    {
        Console.WriteLine("Добавление студента");
        Console.WriteLine("Введите номер курса, название группы, имя, фамилию, возраст, отчество(опционально) через ';'");
        while (true)
        {
            string[] _params = Console.ReadLine().Split(";");
            if (_params.Length < 5)
            {
                Console.WriteLine("Параметров не может быть меньше 5");
                continue;
            }
            if (!int.TryParse(_params[0], out int courseNumber))
            {
                Console.WriteLine("Неверный формат ввода номера курса");
                continue;
            }
            if (String.IsNullOrEmpty(_params[1]))
            {
                Console.WriteLine("Неверный формат ввода названия группы");
                continue;
            }
            if (String.IsNullOrEmpty(_params[2]))
            {
                Console.WriteLine("Неверный формат ввода имени");
                continue;
            }
            if (String.IsNullOrEmpty(_params[3]))
            {
                Console.WriteLine("Неверный формат ввода фамилии");
                continue;
            }
            if (!int.TryParse(_params[4], out int age))
            {
                Console.WriteLine("Неверный формат ввода возраста");
                continue;
            }

            Course c = CourseRepo.getCourseRepo().courses.FirstOrDefault(x => x.CourseNumber == courseNumber);
            if (c == null)
            {
                Console.WriteLine("Курс не найден.");
                continue;
            }
            Student st = Student.CreateNew(_params[2], _params[3], age, (_params.Length > 5 ? _params[5] : null), _params[1], c);
            entities.Add(st);
            return;
        }
    }

    void IContext<Student>.AdditionalMenu()
    {
        Console.WriteLine("4. Просмотр информации о студенте");
    }

    public void Delete()
    {
        while (true)
        {
            string id = Console.ReadLine();
            if (String.IsNullOrEmpty(id))
            {
                Console.WriteLine("Неверный формат ввода идентификатора");
                continue;
            }
            var entity = entities.FirstOrDefault(x => x.Id == new Guid(id));
            if (entity == null)
            {
                Console.WriteLine("Данный идентификатор не найден");
                continue;
            }
            entities.Remove(entity);
            return;
        }
    }

    public void Update()
    {
        Console.WriteLine("Обновление студента");
        Console.WriteLine("Введите идентификатор студента");
        bool idEntered = false;
        Student entity = null!;
        while (entity == null)
        {
            string id = Console.ReadLine();
            if (String.IsNullOrEmpty(id))
            {
                Console.WriteLine("Неверный формат идентификатора");
                continue;
            }
            entity = entities.FirstOrDefault(x => x.Id == new Guid(id))!;
            if (entity == null)
            {
                Console.WriteLine("Запись с данным идентификатором не найдена");
            }
        }

        Console.WriteLine("Введите курс");
        string input = Console.ReadLine();
        if (!String.IsNullOrEmpty(input))
        {
            if (!int.TryParse(input, out int courseNumber))
            {
                Console.WriteLine("Неверный формат ввода номера курса. Пропуск...");
            }
            else
            {
                Course c = CourseRepo.getCourseRepo().courses.FirstOrDefault(x => x.CourseNumber == courseNumber);
                if (c == null)
                {
                    Console.WriteLine("Курс не найден");
                }
                else
                {
                    entity.Course = c;
                }
            }

        }
        Console.WriteLine("Введите группу");
        string group = Console.ReadLine();
        if (!String.IsNullOrEmpty(group))
        {
            entity.Group = group;
        }
        Console.WriteLine("Введите имя");
        string name = Console.ReadLine();
        if (!String.IsNullOrEmpty(name))
        {
            entity.Name = name;
        }
        Console.WriteLine("Введите фамилию");
        string lastname = Console.ReadLine();
        if (!String.IsNullOrEmpty(lastname))
        {
            entity.Lastname = lastname;
        }
        Console.WriteLine("Введите возраст");
        string ageInput = Console.ReadLine();
        if (!String.IsNullOrEmpty(ageInput))
        {
            if (!int.TryParse(input, out int age))
            {
                Console.WriteLine("Неверный формат ввода возраста. Пропуск...");
            }
            else
            {
                entity.Age = age;
            }

        }
        Console.WriteLine("Введите отчество");
        string patronymic = Console.ReadLine();
        if (!String.IsNullOrEmpty(patronymic))
        {
            entity.Patronymic = patronymic;
        }
        return;
    }
}