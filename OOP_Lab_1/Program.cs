using Lab_1;

while (true)
{
    Console.WriteLine($@"Перейти в раздел -->
1. Студенты
2. Преподаватели
3. Дисциплины");
    int selection = 0;
    while (!new[] { 1, 2, 3 }.Contains(selection))
    {
        while (!int.TryParse(Console.ReadLine(), out selection))
        {
            Console.WriteLine("Неверный формат ввода");
        }
    }
    IContext<IEntity> context = null;
    switch (selection)
    {
        case 1:
            //Feed a repo to context and remove T classes.
            context = new StudentContext();
            break;
        case 2:
            context = new LecturerContext();
            break;
        case 3:
            context = new DisciplineContext();
            break;

    }
    context.Dialog();
}