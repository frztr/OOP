
namespace Global;
public class RepairHistoryControllerDto
{
    public int Id { get; set; }
	public int VehicleId { get; set; }
	public DateTime DatetimeBegin { get; set; }
	public DateTime? DatetimeEnd { get; set; }
	public string CompletedWork { get; set; }
	public decimal? Price { get; set; }
	public long? ServicestationTinNumber { get; set; }
	public short? AutomechanicId { get; set; }
}