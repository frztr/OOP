
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddMaintenanceTypeServiceDto
{
    [Required]
	[StringLength(30)]
	public string Name { get; set; }
}