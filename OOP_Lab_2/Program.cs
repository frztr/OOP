// See https://aka.ms/new-console-template for more information
using Lab2;

Console.WriteLine("Начало программы");
while (true)
{
    int? selection = null;
    Console.WriteLine($@"Меню:
    1. Добавить круг
    2. Добавить прямоугольник
    3. Вывести информацию о фигурах в списке
    4. Вывести информацию о фигурах в очереди
    5. Вывести информацию о фигурах в стеке
    6. Выйти из программы");
    while (selection == null)
    {
        selection = new ReadValueDialog<int?>("пункт меню", false).Dialog();
        if (selection < 1 || selection > 6)
        {
            Console.WriteLine("Выбран неверный пункт меню");
            selection = null;
        }
    }

    switch (selection)
    {
        case 1:
            new AddCircleDialog().Dialog();
            break;
        case 2:
            new AddRectangleDialog().Dialog();
            break;
        case 3:
            DataStructures.getStructures().DisplayInfo(DataStructure.LIST);
            break;
        case 4:
            DataStructures.getStructures().DisplayInfo(DataStructure.QUEUE);
            break;
        case 5:
            DataStructures.getStructures().DisplayInfo(DataStructure.STACK);
            break;
        case 6:
            return;
    }

}