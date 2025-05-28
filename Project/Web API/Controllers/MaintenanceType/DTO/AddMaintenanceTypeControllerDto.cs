
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddMaintenanceTypeControllerDto
{
	[Required]
	[StringLength(30)]
	public string Name { get; set; }
}