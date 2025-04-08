
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddFuelTypeControllerDto
{
    [Required]
	[StringLength(20)]
	public string Name { get; set; }
}