
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddFriendshipsStatusControllerDto
{
	[Required]
	[StringLength(10)]
	public string Name { get; set; }
}