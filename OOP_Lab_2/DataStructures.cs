namespace Lab2;

public enum DataStructure
{
    STACK = 1,
    QUEUE = 2,
    LIST = 3
}

public class DataStructures
{
    private static DataStructures data;
    private DataStructures()
    {

    }

    public static DataStructures getStructures()
    {
        if (data == null) data = new DataStructures();
        return data;
    }
    private Stack<Shape> stack = new Stack<Shape>();
    private List<Shape> list = new List<Shape>();

    private Queue<Shape> queue = new Queue<Shape>();

    public void Add(Shape shape, DataStructure structureType)
    {
        switch (structureType)
        {
            case DataStructure.STACK:
                stack.Push(shape);
                break;
            case DataStructure.LIST:
                list.Add(shape);
                break;
            case DataStructure.QUEUE:
                queue.Enqueue(shape);
                break;
        }
    }
    public void DisplayInfo(DataStructure structureType)
    {
        Console.WriteLine("Вывод информации:");
        List<Shape> values = new List<Shape>();
        switch (structureType)
        {

            case DataStructure.STACK:
                Console.WriteLine("Стек:");
                values = stack.ToList();
                break;
            case DataStructure.LIST:
                Console.WriteLine("Список:");
                values = list;
                break;
            case DataStructure.QUEUE:
            Console.WriteLine("Очередь:");
                values = queue.ToList();
                break;
        }
        values.ForEach(x => x.DisplayInfo());
    }
}