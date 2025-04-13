
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateVehicleCategoryServiceDto
{
    [Required]
	public short Id { get; set; }
	[StringLength(25)]
	public string? Name { get; set; }
}