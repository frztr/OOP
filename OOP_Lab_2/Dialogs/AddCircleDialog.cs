namespace Lab2;

public class AddCircleDialog : IDialog
{
    public void Dialog()
    {
        double? r = null;
        while (r == null)
        {
            r = new ReadValueDialog<double>("радиус", false).Dialog();
        }
        Console.WriteLine($@"Введите тип структуры:
        1. Стек
        2. Очередь
        3. Список");
        DataStructure? structureType = null;
        while (structureType == null)
        {
            structureType = new ReadValueDialog<DataStructure>("номер структуры", false).Dialog();
        }
        DataStructures.getStructures().Add(new Circle(r.Value), structureType.Value);
    }
}