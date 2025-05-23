
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddRoleServiceDto
{
	[Required]
	[StringLength(15)]
	public string Name { get; set; }
}