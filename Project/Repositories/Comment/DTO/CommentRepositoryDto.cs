
namespace Global;
public class CommentRepositoryDto
{
    public long Id { get; set; }
	public long PostId { get; set; }
	public long UserId { get; set; }
	public long? ParentCommentId { get; set; }
	public string Content { get; set; }
	public DateTime? CreatedAt { get; set; }
	public DateTime? UpdatedAt { get; set; }
}