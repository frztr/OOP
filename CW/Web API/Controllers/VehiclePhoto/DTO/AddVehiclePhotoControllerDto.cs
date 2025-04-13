
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddVehiclePhotoControllerDto
{
	[Required]
	[StringLength(255)]
	public string Src { get; set; }
	[Required]
	public int VehicleId { get; set; }
}