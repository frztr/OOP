
namespace Global;
public class AddVehicleModelControllerDto
{
public string Name { get; set; }
	public short ManufacturerId { get; set; }
	public short VehicleCategoryId { get; set; }
	public short Power { get; set; }
	public short FuelTypeId { get; set; }
	public int LoadCapacity { get; set; }
}