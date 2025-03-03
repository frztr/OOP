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
    int actionSelection = -1;
    switch (selection)
    {
        case 1:
            Console.WriteLine("Переход к разделу Студенты");
            while (!new[] { 1, 2, 3, 4, 0 }.Contains(actionSelection))
            {
                while (!int.TryParse(Console.ReadLine(), out actionSelection))
                {
                    Console.WriteLine("Неверный формат ввода");
                }
            }
            Console.WriteLine($@"Выберите действие -->
1. Добавить студента
2. Изменить студента
3. Удалить студента");

            // switch(actionSelection){
                
            // }



            break;
        case 2:
            Console.WriteLine("Переход к разделу Преподаватели");
            break;
        case 3:
            Console.WriteLine("Переход к разделу Дисциплины");
            break;

    }
}