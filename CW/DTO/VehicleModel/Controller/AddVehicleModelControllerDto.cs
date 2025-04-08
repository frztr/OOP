
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddVehicleModelControllerDto
{
    [Required]
	[StringLength(40)]
	public string Name { get; set; }
	[Required]
	public short ManufacturerId { get; set; }
	[Required]
	public short VehicleCategoryId { get; set; }
	[Required]
	public short Power { get; set; }
	[Required]
	public short FuelTypeId { get; set; }
	[Required]
	public int LoadCapacity { get; set; }
}