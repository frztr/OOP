namespace Lab_1;
public interface IContext<out T>
{
    public abstract IEnumerable<T> entities {get;}
    public void Add();
    public void Update();
    public void Delete();
    public abstract string Name { get; }

    private void DisplayMenu()
    {
        Console.WriteLine($@"Опции:
0. Выйти из раздела.
1. Добавление
2. Обновление
3. Удаление");
    }

    protected void AdditionalMenu(){
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



    public virtual bool AdditionalOptions(int selection){
        return false;
    }
}