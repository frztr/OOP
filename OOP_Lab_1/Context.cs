namespace Lab_1;
public abstract class Context
{
    public abstract void Add();
    public abstract void Update();
    public abstract void Delete();
    public abstract string Name { get; }

    protected virtual void DisplayMenu()
    {
        Console.WriteLine($@"
0. Выйти из раздела.
1. Добавление
2. Обновление
3. Удаление");
    }
    public void Dialog()
    {
        while (true)
        {
            Console.WriteLine($@"Раздел {Name}");
            DisplayMenu();
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