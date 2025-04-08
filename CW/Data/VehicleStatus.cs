namespace Global;
public class VehicleStatus
{
    public short Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<Vehicle> Vehicles { get; set; }
}