
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddCommentLikeControllerDto
{
	[Required]
	public long Id { get; set; }
	[Required]
	public long CommentId { get; set; }
	[Required]
	public long UserId { get; set; }
	public DateTime? CreatedAt { get; set; }
}