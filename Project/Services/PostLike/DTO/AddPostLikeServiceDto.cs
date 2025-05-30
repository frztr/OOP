
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddPostLikeServiceDto
{
	[Required]
	public long Id { get; set; }
	[Required]
	public long PostId { get; set; }
	[Required]
	public long UserId { get; set; }
	public DateTime? CreatedAt { get; set; }
}