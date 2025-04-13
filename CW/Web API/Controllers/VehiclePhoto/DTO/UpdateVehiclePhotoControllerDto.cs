
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateVehiclePhotoControllerDto
{
    [Required]
	public int Id { get; set; }
	public int? VehicleId { get; set; }
}