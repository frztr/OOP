
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddFriendshipsRepositoryDto
{
	[Required]
	public long Id { get; set; }
	[Required]
	public long User1Id { get; set; }
	[Required]
	public long User2Id { get; set; }
	[Required]
	public short FriendshipsStatusId { get; set; }
	public DateTime? CreatedAt { get; set; }
	public DateTime? UpdatedAt { get; set; }
}