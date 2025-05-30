
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateMessageServiceDto
{
    [Required]
	public long Id { get; set; }
	public long? SenderId { get; set; }
	public long? ReceiverId { get; set; }
	[StringLength(512)]
	public string? Content { get; set; }
	public DateTime? SentAt { get; set; }
	public long? ReplyTo { get; set; }
}