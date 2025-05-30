
namespace Global;
public class PostRepositoryDto
{
    public long Id { get; set; }
	public long UserId { get; set; }
	public string Content { get; set; }
	public DateTime? CreatedAt { get; set; }
	public DateTime? UpdatedAt { get; set; }
}