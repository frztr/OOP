
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddVehiclePhotoServiceDto
{
    [Required]
	[StringLength(255)]
	public string Src { get; set; }
	[Required]
	public int VehicleId { get; set; }
}