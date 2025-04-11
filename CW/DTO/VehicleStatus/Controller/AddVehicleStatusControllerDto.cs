
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddVehicleStatusControllerDto
{
	[Required]
	[StringLength(20)]
	public string Name { get; set; }
}