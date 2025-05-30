
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddFriendshipsStatusRepositoryDto
{
	[Required]
	[StringLength(10)]
	public string Name { get; set; }
}