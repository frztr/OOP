
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddRoleRepositoryDto
{
	[Required]
	[StringLength(15)]
	public string Name { get; set; }
}