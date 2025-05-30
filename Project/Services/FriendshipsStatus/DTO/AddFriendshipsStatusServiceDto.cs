
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddFriendshipsStatusServiceDto
{
	[Required]
	[StringLength(10)]
	public string Name { get; set; }
}