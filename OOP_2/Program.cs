using ConsoleApp2;

// Car car = new("Toyota",1800,"Corolla",4);
// car.DisplayInfo();

VehicleManagementSystem vms = new VehicleManagementSystem();

while (true)
{
    Console.WriteLine("1 - добавить новый автомобиль");
    Console.WriteLine("2 - вывод всех автомобилей");
    Console.WriteLine("3 - добавить новый мотоцикл");


    bool isNum = int.TryParse(Console.ReadLine(), out int selection);
    if (!isNum) continue;

    List<string> _params = new List<string>();
    bool cond1;
    bool cond2;
    int year;
    switch (selection)
    {
        case 1:
            Console.WriteLine("Введите марку автомобиля, год выпуска, модель, кол-во дверей");
            _params = (Console.ReadLine() ?? "").Split(" ").ToList();
            if (_params.Count < 4)
            {
                Console.WriteLine("Введено неверное количество параметров");
                continue;
            }
            cond1 = int.TryParse(_params[3], out int countdoors);
            cond2 = int.TryParse(_params[1], out year);
            if (!cond1 || !cond2)
            {
                Console.WriteLine("Неверный формат ввода");
                continue;
            }
            vms.AddNewVehicle(new Car(_params[0], year, _params[2], countdoors));
            break;
        case 2:
            Console.WriteLine("Вывод списка транспортных средств");
            vms.DisplayList();
            Console.WriteLine();
            break;
        case 3:
            Console.WriteLine("Введите марку мотоцикла, год выпуска, модель, наличие инвалидной коляски");
            _params = (Console.ReadLine() ?? "").Split(" ").ToList();
            if (_params.Count < 4)
            {
                Console.WriteLine("Введено неверное количество параметров");
                continue;
            }
            cond1 = bool.TryParse(_params[3], out bool kolayaska);
            cond2 = int.TryParse(_params[1], out year);
            if (!cond1 || !cond2)
            {
                Console.WriteLine("Неверный формат ввода");
                continue;
            }
            vms.AddNewVehicle(new Motocycle(_params[0], year, _params[2], kolayaska));
            break;
        default:
            Console.WriteLine("Введен некорректный номер действия");
            break;
    }
}
