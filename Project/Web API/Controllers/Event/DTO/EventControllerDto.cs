
namespace Global;
public class EventControllerDto
{
    public int Id { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public short LocationId { get; set; }
	public DateTime StartTime { get; set; }
	public DateTime EndTime { get; set; }
	public long CreatedBy { get; set; }
	public short EventCategoryId { get; set; }
}