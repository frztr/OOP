
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddEventServiceDto
{
	[Required]
	[StringLength(50)]
	public string Title { get; set; }
	[Required]
	[StringLength(300)]
	public string Description { get; set; }
	[Required]
	public short LocationId { get; set; }
	[Required]
	public DateTime StartTime { get; set; }
	[Required]
	public DateTime EndTime { get; set; }
	[Required]
	public long CreatedBy { get; set; }
	[Required]
	public short EventCategoryId { get; set; }
}