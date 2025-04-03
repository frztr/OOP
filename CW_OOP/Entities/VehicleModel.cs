namespace Global;
public class VehicleModel : IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public short ManufacturerId { get; set; }
    public short VehicleCategoryId { get; set; }
    public short Power { get; set; }
    public short FuelTypeId { get; set; }
    public int LoadCapacity { get; set; }
    
    public Manufacturer Manufacturer { get; set; }
    public VehicleCategory VehicleCategory { get; set; }
    public FuelType FuelType { get; set; }
    public ICollection<Vehicle> Vehicles { get; set; }
}