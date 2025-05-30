
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateFriendshipsStatusControllerDto
{
    [Required]
	public short Id { get; set; }
	[StringLength(10)]
	public string? Name { get; set; }
}