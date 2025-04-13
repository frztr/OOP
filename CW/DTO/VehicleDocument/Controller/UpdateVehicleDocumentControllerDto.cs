
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateVehicleDocumentControllerDto
{
    [Required]
	public int Id { get; set; }
	public short? DoctypeId { get; set; }
	[StringLength(255)]
	public string? Src { get; set; }
	public int? VehicleId { get; set; }
}