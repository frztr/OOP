
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateVehicleDocumentControllerDto
{
    [Required]
	public int Id { get; set; }
	public short? DoctypeId { get; set; }
	public int? VehicleId { get; set; }
}