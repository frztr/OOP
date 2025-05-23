
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateEventControllerDto
{
    [Required]
	public int Id { get; set; }
	[StringLength(50)]
	public string? Title { get; set; }
	[StringLength(300)]
	public string? Description { get; set; }
	public short? LocationId { get; set; }
	public DateTime? StartTime { get; set; }
	public DateTime? EndTime { get; set; }
	public long? CreatedBy { get; set; }
	public short? EventCategoryId { get; set; }
}