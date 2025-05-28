
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddReviewControllerDto
{
	[Required]
	public long UserId { get; set; }
	[Required]
	public short EventId { get; set; }
	[Required]
	public short Rating { get; set; }
	[StringLength(500)]
	public string? Comment { get; set; }
	public DateTime? ReviewDate { get; set; }
}