
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddRoleControllerDto
{
	[Required]
	[StringLength(15)]
	public string Name { get; set; }
}