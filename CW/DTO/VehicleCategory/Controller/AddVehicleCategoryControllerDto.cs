
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddVehicleCategoryControllerDto
{
    [Required]
	[StringLength(25)]
	public string Name { get; set; }
}