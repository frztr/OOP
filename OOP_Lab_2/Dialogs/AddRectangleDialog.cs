namespace Lab2;
public class AddRectangleDialog : IDialog
{
    public void Dialog()
    {
        double? w = null;
        double? h = null;
        while (w == null)
        {
            w = new ReadValueDialog<double>("длина", false).Dialog();
        }
        while (h == null)
        {
            h = new ReadValueDialog<double>("высота", false).Dialog();
        }
        Console.WriteLine($@"Введите тип структуры:
        1. Стек
        2. Очередь
        3. Список");
        DataStructure? structureType = null;
        while (structureType == null)
        {
            structureType = new ReadValueDialog<DataStructure>("номер структуры данных", false).Dialog();
        }
        DataStructures.getStructures().Add(new Rectangle(w.Value, h.Value), structureType.Value);
    }
}