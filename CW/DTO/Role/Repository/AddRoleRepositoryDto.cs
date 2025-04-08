
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddRoleRepositoryDto
{
    [Required]
	[StringLength(30)]
	public string Name { get; set; }
}