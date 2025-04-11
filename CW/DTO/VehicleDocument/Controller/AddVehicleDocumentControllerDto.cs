
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddVehicleDocumentControllerDto
{
	[Required]
	public short DocTypeId { get; set; }
	[Required]
	[StringLength(255)]
	public string Src { get; set; }
	[Required]
	public int VehicleId { get; set; }
}