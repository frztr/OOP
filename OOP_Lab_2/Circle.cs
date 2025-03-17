namespace Lab2;
public class Circle : Shape{

    private double radius;
    public Circle(double radius){
        this.radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI*radius*radius;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("Круг:");
        base.DisplayInfo();
    }
}