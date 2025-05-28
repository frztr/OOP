
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddRoleControllerDto
{
	[Required]
	[StringLength(30)]
	public string Name { get; set; }
}