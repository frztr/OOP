
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddMaintenanceTypeRepositoryDto
{
    [Required]
	[StringLength(30)]
	public string Name { get; set; }
}