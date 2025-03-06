namespace Lab_1;
public interface IContext<out T> where T : IEntity
{
    protected static IEnumerable<T> Entities { get; set; } = new List<T>();
    public void Add();
    public void Update();
    public void Delete(){
        var _this = (IContext<IEntity>)this;
        Guid id = _this.ReadDialog<Guid>("идентификатор");
        var entity = Entities.FirstOrDefault(x => x.Id == id);
        if (entity == null)
        {
            Console.WriteLine("Запись с данным идентификатором не найдена");
            return;
        }
        Entities = Entities.Where(x=>x.Id!=id);
        return;
    }
    public string Name { get; }

    private void DisplayMenu()
    {
        Console.WriteLine($@"Опции:
0. Выйти из раздела.
1. Добавление
2. Обновление
3. Удаление");
    }

    protected void AdditionalMenu()
    {
        return;
    }

    public void Dialog()
    {
        while (true)
        {
            Console.WriteLine($@"Раздел {Name}");
            DisplayMenu();
            AdditionalMenu();
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
                    Add();
                    break;
                case 2:
                    Update();
                    break;
                case 3:
                    Delete();
                    break;
                default:
                    if (!AdditionalOptions(selection))
                        Console.WriteLine("Введен неверный пункт");
                    break;
            }
        }

    }

    public K? ReadDialog<K>(string propname,bool ignoreEmptyField = true)
    {
        Console.WriteLine($@"Введите свойство '{propname}'");
        string input = Console.ReadLine();
        if (String.IsNullOrEmpty(input))
        {
            if(!ignoreEmptyField){
                Console.WriteLine($@"Свойство '{propname}' не может быть пустым.");
            }
            return default(K);
        }
        if (typeof(string) == typeof(K))
        {
            return (K)(object)input;
        }
        if (typeof(int) == typeof(K) || typeof(int?) == typeof(K))
        {
            if (!int.TryParse(input, out int e))
            {
                Console.WriteLine($@"Неверный формат ввода поля '{propname}'.");
                return default(K);
            }
            else
            {
                return (K)(object)e;
            }
        }
        if (typeof(Guid) == typeof(K))
        {
            if (!Guid.TryParse(input, out Guid id))
            {
                Console.WriteLine("Неверный формат идентификатора");
                return default(K);
            }
            else{
                return (K)(object)id;
            }
        }
        if (typeof(Course) == typeof(K))
        {
            if (int.TryParse(input, out int courseNumber))
            {
                Course c = CourseRepo.getCourseRepo().courses.FirstOrDefault(x => x.CourseNumber == courseNumber);
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
                Console.WriteLine($@"Неверный формат ввода поля '{propname}'.");
            }
        }
        return default(K);
    }

    public bool AdditionalOptions(int selection)
    {
        return false;
    }
}