
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddVehiclePhotoControllerDto
{
	[Required]
	public IFormFile Photo { get; set; }
	[Required]
	public int VehicleId { get; set; }
}