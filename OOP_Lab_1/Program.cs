using Lab_1;

List<Student> students = new List<Student>();
List<Lecturer> lecturers = new List<Lecturer>();
List<Discipline> disciplines = new List<Discipline>();

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