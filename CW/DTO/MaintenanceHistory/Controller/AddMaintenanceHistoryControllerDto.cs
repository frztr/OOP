
namespace Global;
public class AddMaintenanceHistoryControllerDto
{
public DateTime Date { get; set; }
	public int VehicleId { get; set; }
	public short MaintenanceTypeId { get; set; }
	public string CompletedWork { get; set; }
	public short AutomechanicId { get; set; }
}