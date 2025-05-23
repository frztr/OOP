
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateRoleServiceDto
{
    [Required]
	public short Id { get; set; }
	[StringLength(15)]
	public string? Name { get; set; }
}