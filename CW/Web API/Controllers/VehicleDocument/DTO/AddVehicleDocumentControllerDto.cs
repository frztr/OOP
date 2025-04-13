
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddVehicleDocumentControllerDto
{
	[Required]
	public short DoctypeId { get; set; }
	[Required]
	public IFormFile File { get; set; }
	[Required]
	public int VehicleId { get; set; }
}