namespace ConsoleApp2;
public class Car : Vehicle
{

    public int countdoors;
    public Car(string mark, int year, string model, int countdoors) : base(mark, year, model)
    {
        this.countdoors = countdoors;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($@"Кол-во дверей: {countdoors}");
    }
}