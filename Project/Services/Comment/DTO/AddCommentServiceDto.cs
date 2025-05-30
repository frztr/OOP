
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddCommentServiceDto
{
	[Required]
	public long Id { get; set; }
	[Required]
	public long PostId { get; set; }
	[Required]
	public long UserId { get; set; }
	public long? ParentCommentId { get; set; }
	[Required]
	[StringLength(512)]
	public string Content { get; set; }
	public DateTime? CreatedAt { get; set; }
	public DateTime? UpdatedAt { get; set; }
}