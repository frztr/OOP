
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddManufacturerControllerDto
{
    [Required]
	[StringLength(20)]
	public string Name { get; set; }
}