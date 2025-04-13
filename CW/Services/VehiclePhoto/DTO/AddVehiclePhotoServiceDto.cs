
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace Global;
public class AddVehiclePhotoServiceDto
{
	[Required]
	public IFormFile Photo { get; set; }
	[Required]
	public int VehicleId { get; set; }
}