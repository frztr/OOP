
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddManufacturerServiceDto
{
    [Required]
	[StringLength(20)]
	public string Name { get; set; }
}