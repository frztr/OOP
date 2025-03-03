namespace ConsoleApp2;

public class Motocycle : Vehicle
{
    protected bool kolyaska;

    public Motocycle(string mark, int year, string model, bool kolayaska) : base(mark, year, model)
    {
        this.kolyaska = kolayaska;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Есть коляска: {(kolyaska ? "Да":"Нет")}");
    }
}