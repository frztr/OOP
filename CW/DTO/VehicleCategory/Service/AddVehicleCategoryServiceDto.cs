
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddVehicleCategoryServiceDto
{
    [Required]
	[StringLength(25)]
	public string Name { get; set; }
}