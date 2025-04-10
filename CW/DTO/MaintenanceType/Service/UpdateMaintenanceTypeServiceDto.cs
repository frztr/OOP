
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateMaintenanceTypeServiceDto
{
    [Required]
	public short Id { get; set; }
    
    [StringLength(30)]
	public string? Name { get; set; }
}