namespace ConsoleApp2;

public abstract class Vehicle
{
    protected string mark;
    protected int year;
    protected string model;
    public Vehicle(string mark, int year, string model){
        this.mark = mark;
        this.year = year;
        this.model = model;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"{mark} {year} {model}");
    }

    public void Move()
    {
        Console.WriteLine("Транспортное средство движется");
    }
}