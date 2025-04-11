
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddVehicleControllerDto
{
	[Required]
	[StringLength(17)]
	public string VinNumber { get; set; }
	[Required]
	[StringLength(15)]
	public string PlateNumber { get; set; }
	[Required]
	public int VehicleModelId { get; set; }
	[Required]
	public short ReleaseYear { get; set; }
	[Required]
	public DateTime RegistrationDate { get; set; }
	[Required]
	public short StatusId { get; set; }
}