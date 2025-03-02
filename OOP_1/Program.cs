using OOP_1;

// Student student = new Student("Петров","Петр","Петрович",18,"ТСО-305-22");
// student.Print();


Console.WriteLine("Это программа по управлению данными студентов");
Console.WriteLine("------------");
StudentManagementSystem sms = new StudentManagementSystem();
while (true)
{

    Console.WriteLine("1. Вывести список студентов");
    Console.WriteLine("2. Поиск");
    Console.WriteLine("3. Добавление студента");
    Console.WriteLine("4. Удаление студента");
    Console.WriteLine("0. Закрыть программу");
    Console.WriteLine("------------");
    Console.Write("Выберите действие: ");
    bool isNumber = int.TryParse(Console.ReadLine(), out int selection);
    if (!isNumber)
    {
        Console.WriteLine("Введено не число");
        continue;
    }
    Console.WriteLine($@"Введено: {selection}.");
    string name = "";
    string lastname = "";
    string patronymic = "";
    string group = "";
    switch (selection)
    {
        case 0:
            Console.WriteLine("Закрытие программы.");
            return;
        case 1:
            Console.WriteLine("Вывод студентов.");
            sms.DisplayStudentsList();
            break;
        case 2:
            Console.WriteLine("Поиск студента.");
            Console.WriteLine("Введите имя:");
            name = Console.ReadLine();
            Console.WriteLine("Введите фамилия:");
            lastname = Console.ReadLine();
            Console.WriteLine("Введите отчество:");
            patronymic = Console.ReadLine();
            Console.WriteLine("Введите группу:");
            group = Console.ReadLine();
            Console.WriteLine($@"Список студентов удовлетворяющих запросу:
Имя:{name}, Фамилия:{lastname}, Отчество:{patronymic}, Группа:{group}");
            sms.FindStudents(name, lastname, patronymic, group);
            break;
        case 3:
            Console.WriteLine("Добавление студента.");
            Console.WriteLine("Введите имя:");
            name = Console.ReadLine();
            Console.WriteLine("Введите фамилия:");
            lastname = Console.ReadLine();
            Console.WriteLine("Введите отчество:");
            patronymic = Console.ReadLine();
            Console.WriteLine("Введите возраст:");
            int age = 0;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Введено не число. Введите возраст заново.");
            }
            Console.WriteLine("Введите группу:");
            group = Console.ReadLine();
            Student student = new Student(name, lastname, patronymic, age, group);
            sms.AddStudent(student);
            Console.WriteLine("Добавлен студент:");
            student.DisplayData();
            break;
        case 4:
            Console.WriteLine("Удаление студента.");
            Console.WriteLine("Введите идентификатор студента.");
            sms.RemoveStudent(new Guid(Console.ReadLine()));
            break;
        default:
            Console.WriteLine("Введен неверный пункт");
            break;
    }
}
