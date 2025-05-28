
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateVehicleStatusControllerDto
{
    [Required]
	public short Id { get; set; }
	[StringLength(20)]
	public string? Name { get; set; }
}