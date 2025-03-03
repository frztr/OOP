namespace ConsoleApp2;

public class VehicleManagementSystem
{
    private List<Vehicle> vehicles = new List<Vehicle>();

    public void AddNewVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void DisplayList(){
        vehicles.ForEach(x=>{
            x.DisplayInfo();
            Console.WriteLine();
        });
    }
}