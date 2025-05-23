
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateReviewControllerDto
{
    [Required]
	public long Id { get; set; }
	public long? UserId { get; set; }
	public short? EventId { get; set; }
	public short? Rating { get; set; }
	[StringLength(500)]
	public string? Comment { get; set; }
	public DateTime? ReviewDate { get; set; }
}