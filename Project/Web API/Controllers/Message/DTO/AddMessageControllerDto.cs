
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddMessageControllerDto
{
	[Required]
	public long Id { get; set; }
	[Required]
	public long SenderId { get; set; }
	[Required]
	public long ReceiverId { get; set; }
	[Required]
	[StringLength(512)]
	public string Content { get; set; }
	public DateTime? SentAt { get; set; }
	public long? ReplyTo { get; set; }
}