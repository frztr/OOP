namespace Global;
public class VehicleStatus : IEntity<short>
{
    public short Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<Vehicle> Vehicles { get; set; }
}