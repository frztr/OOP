
namespace Global;
public class CommentLikeServiceDto
{
    public long Id { get; set; }
	public long CommentId { get; set; }
	public long UserId { get; set; }
	public DateTime? CreatedAt { get; set; }
}