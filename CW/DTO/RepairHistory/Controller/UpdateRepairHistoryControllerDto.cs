
namespace Global;
public class UpdateRepairHistoryControllerDto
{
    public int Id { get; set; }
    public int? VehicleId { get; set; }
	public DateTime? DateTimeBegin { get; set; }
	public DateTime? DateTimeEnd { get; set; }
	public string? CompletedWork { get; set; }
}