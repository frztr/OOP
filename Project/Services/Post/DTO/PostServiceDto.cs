
namespace Global;
public class PostServiceDto
{
    public long Id { get; set; }
	public long UserId { get; set; }
	public string Content { get; set; }
	public DateTime? CreatedAt { get; set; }
	public DateTime? UpdatedAt { get; set; }
}