
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateVehicleCategoryControllerDto
{
    [Required]
    	public short Id { get; set; }
    
    	[StringLength(25)]
	public string Name { get; set; }
}