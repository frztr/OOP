
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddRoleRepositoryDto
{
	[Required]
	[StringLength(20)]
	public string Name { get; set; }
	[StringLength(100)]
	public string? Description { get; set; }
}