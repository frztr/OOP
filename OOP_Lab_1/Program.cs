using Lab_1;

while (true)
{

    Console.WriteLine($@"Перейти в раздел -->
1. Студенты
2. Преподаватели
3. Дисциплины
0. Выйти");
    int selection = -1;
    while (!new[] { 1, 2, 3, 0 }.Contains(selection))
    {
        while (!int.TryParse(Console.ReadLine(), out selection))
        {
            Console.WriteLine("Неверный формат ввода");
        }
    }
    IContext context = null;
    switch (selection)
    {
        case 1:
            context = new StudentContext();
            break;
        case 2:
            context = new LecturerContext();
            break;
        case 3:
            context = new DisciplineContext();
            break;
        case 0:
            return;

    }
    context.ShowContext();
}