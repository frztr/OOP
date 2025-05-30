
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateCommentControllerDto
{
    [Required]
	public long Id { get; set; }
	public long? PostId { get; set; }
	public long? UserId { get; set; }
	public long? ParentCommentId { get; set; }
	[StringLength(512)]
	public string? Content { get; set; }
	public DateTime? CreatedAt { get; set; }
	public DateTime? UpdatedAt { get; set; }
}