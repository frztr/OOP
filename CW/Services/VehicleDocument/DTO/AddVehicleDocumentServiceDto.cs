
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace Global;
public class AddVehicleDocumentServiceDto
{
	[Required]
	public short DoctypeId { get; set; }
	[Required]
	public IFormFile File { get; set; }
	[Required]
	public int VehicleId { get; set; }
}