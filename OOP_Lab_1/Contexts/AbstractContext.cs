using System.Threading.Tasks;

namespace Lab_1;
public abstract class AbstractContext<T> : IContextSpecified<T>
where T : IEntity
{
    protected List<T> Entities = GlobalStorage.GetStorage().GetList<T>();
    protected abstract string Name { get; }
    protected abstract Task Add();
    protected abstract Task Update();

    protected abstract string SearchCriteria(T item);
    protected virtual async Task Delete()
    {
        Guid id = ReadValueDialog<Guid>("идентификатор");
        var entity = Entities.FirstOrDefault(x => x.Id == id);
        if (entity == null)
        {
            Console.WriteLine("Запись с данным идентификатором не найдена");
        }
        Entities.Remove(entity);
        Console.WriteLine("Запись удалена");
        await GlobalStorage.GetStorage().SaveChanges();
    }

    protected void DisplayMenu()
    {
        Console.WriteLine($@"Опции:
0. Выйти из раздела.
1. Добавление
2. Обновление
3. Удаление
4. Поиск");
    }

    protected virtual async Task AdditionalMenu() { }

    protected virtual async Task<bool> AdditionalOptions(int selection)
    {
        return false;
    }
    //Диалог запроса переменной с последующим конвертированием к требуемому формату, если возможно
    //ignoreEmptyField - для операций обновления можно игнорировать пустые поля, т.к. это будет значить отсутствие изменений данных свойства
    protected K? ReadValueDialog<K>(string propname, bool ignoreEmptyField = true)
    {
        Console.WriteLine($@"Введите параметр '{propname}'");
        string input = Console.ReadLine();
        if (String.IsNullOrEmpty(input))
        {
            if (!ignoreEmptyField)
            {
                Console.WriteLine($@"Параметр '{propname}' не может быть пустым.");
            }
            return default(K);
        }
        if (typeof(K) == typeof(string))
        {
            return (K)(object)input;
        }
        if (typeof(K) == typeof(int) || typeof(K) == typeof(int?))
        {
            if (!int.TryParse(input, out int e))
            {
                Console.WriteLine($@"Неверный формат ввода параметра '{propname}'.");
                return default(K);
            }
            else
            {
                return (K)(object)e;
            }
        }
        if (typeof(K) == typeof(Guid))
        {
            if (!Guid.TryParse(input, out Guid id))
            {
                Console.WriteLine("Неверный формат идентификатора");
                return default(K);
            }
            else
            {
                return (K)(object)id;
            }
        }
        if (typeof(K) == typeof(Course))
        {
            if (int.TryParse(input, out int courseNumber))
            {
                Course c = GlobalStorage.GetStorage().GetList<Course>().FirstOrDefault(x => x.CourseNumber == courseNumber);
                if (c == null)
                {
                    Console.WriteLine("Курс не найден");
                    return default(K);
                }
                else
                {
                    return (K)(object)c;
                }
            }
            else
            {
                Console.WriteLine($@"Неверный формат ввода параметра '{propname}'.");
                return default(K);
            }
        }
        return default(K);
    }

    public async Task ShowContext()
    {
        while (true)
        {
            Console.WriteLine($@"Раздел {Name}");
            DisplayMenu();
            await AdditionalMenu();
            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection))
            {
                Console.WriteLine("Неверный формат ввода");
            }
            switch (selection)
            {
                case 0:
                    return;
                case 1:
                    await Add();
                    break;
                case 2:
                    await Update();
                    break;
                case 3:
                    await Delete();
                    break;
                case 4:
                    Search();
                    break;
                default:
                    if (!(await AdditionalOptions(selection)))
                        Console.WriteLine("Введен неверный пункт");
                    break;
            }
        }

    }

    public T GetByIdDialog()
    {
        T entity = default(T);
        Guid guid = ReadValueDialog<Guid>($@"идентификатор сущности {Name}");
        entity = Entities.FirstOrDefault(x => x.Id == guid)!;
        if (entity == null)
        {
            Console.WriteLine("Запись с данным идентификатором не найдена");
        }
        return entity;
    }

    protected void Search()
    {
        Console.WriteLine($@"Поиск записей. Введите любые известные данные сущности {Name} через пробел.");
        string s = "";
        do
        {
            s = Console.ReadLine();
        }
        while (String.IsNullOrEmpty(s));

        var keywords = s.ToLower().Split(" ");
        Entities.Where(x =>
        {
            foreach (var k in keywords)
            {
                if (!SearchCriteria(x).ToLower().Contains(k)) return false;
            }
            return true;
        }).ToList().ForEach(x => x.DisplayInfo());

    }
}

