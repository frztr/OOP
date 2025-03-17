namespace Lab2;
public abstract class Shape : IShape
{
    public abstract double CalculateArea();

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Площадь: {CalculateArea()}");
    }


}