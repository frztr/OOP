
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddFuelTypeServiceDto
{
	[Required]
	[StringLength(20)]
	public string Name { get; set; }
}