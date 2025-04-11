
namespace Global;
public class RepairHistoryRepositoryDto
{
    public int Id { get; set; }
	public int VehicleId { get; set; }
	public DateTime DateTimeBegin { get; set; }
	public string CompletedWork { get; set; }
}