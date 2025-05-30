
namespace Global;
public class MessageServiceDto
{
    public long Id { get; set; }
	public long SenderId { get; set; }
	public long ReceiverId { get; set; }
	public string Content { get; set; }
	public DateTime? SentAt { get; set; }
	public long? ReplyTo { get; set; }
}