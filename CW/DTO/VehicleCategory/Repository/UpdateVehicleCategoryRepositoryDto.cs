
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateVehicleCategoryRepositoryDto
{
    [Required]
    	public short Id { get; set; }
    
    	[StringLength(25)]
	public string Name { get; set; }
}