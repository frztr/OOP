
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateCommentLikeServiceDto
{
    [Required]
	public long Id { get; set; }
	public long? CommentId { get; set; }
	public long? UserId { get; set; }
	public DateTime? CreatedAt { get; set; }
}