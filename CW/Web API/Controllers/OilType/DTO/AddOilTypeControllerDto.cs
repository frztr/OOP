
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddOilTypeControllerDto
{
	[Required]
	[StringLength(10)]
	public string Name { get; set; }
	[Required]
	public short FuelTypeId { get; set; }
}