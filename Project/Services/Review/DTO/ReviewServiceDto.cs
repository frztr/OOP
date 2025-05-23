
namespace Global;
public class ReviewServiceDto
{
    public long Id { get; set; }
	public long UserId { get; set; }
	public short EventId { get; set; }
	public short Rating { get; set; }
	public string? Comment { get; set; }
	public DateTime? ReviewDate { get; set; }
}