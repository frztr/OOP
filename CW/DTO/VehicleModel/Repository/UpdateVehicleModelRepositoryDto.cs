
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateVehicleModelRepositoryDto
{
    [Required]
    	public int Id { get; set; }
    
    	[StringLength(40)]
	public string Name { get; set; }
		public short ManufacturerId { get; set; }
		public short VehicleCategoryId { get; set; }
		public short Power { get; set; }
		public short FuelTypeId { get; set; }
		public int LoadCapacity { get; set; }
}