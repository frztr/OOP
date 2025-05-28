
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddRoleServiceDto
{
	[Required]
	[StringLength(30)]
	public string Name { get; set; }
}