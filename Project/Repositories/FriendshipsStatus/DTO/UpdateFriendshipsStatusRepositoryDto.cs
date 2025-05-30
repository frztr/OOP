
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateFriendshipsStatusRepositoryDto
{
    [Required]
	public short Id { get; set; }
	[StringLength(10)]
	public string? Name { get; set; }
}