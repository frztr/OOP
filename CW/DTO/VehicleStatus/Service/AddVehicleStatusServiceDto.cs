
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddVehicleStatusServiceDto
{
	[Required]
	[StringLength(20)]
	public string Name { get; set; }
}