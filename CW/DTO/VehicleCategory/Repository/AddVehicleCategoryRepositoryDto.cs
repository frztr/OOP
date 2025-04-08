
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddVehicleCategoryRepositoryDto
{
    [Required]
	[StringLength(25)]
	public string Name { get; set; }
}