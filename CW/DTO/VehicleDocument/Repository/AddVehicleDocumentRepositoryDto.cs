
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddVehicleDocumentRepositoryDto
{
	[Required]
	public short DoctypeId { get; set; }
	[Required]
	[StringLength(255)]
	public string Src { get; set; }
	[Required]
	public int VehicleId { get; set; }
}