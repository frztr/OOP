namespace Lab2;
public class Rectangle : Shape{

    private double width;
    private double height;
    public Rectangle(double width, double height){
        this.width = width;
        this.height = height;
    }

    public override double CalculateArea()
    {
        return width*height;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("Прямоугольник:");
        base.DisplayInfo();
    }
}