
namespace Global;
public class RepairHistoryServiceDto
{
    public int Id { get; set; }
	public int VehicleId { get; set; }
	public DateTime DateTimeBegin { get; set; }
	public string CompletedWork { get; set; }
}