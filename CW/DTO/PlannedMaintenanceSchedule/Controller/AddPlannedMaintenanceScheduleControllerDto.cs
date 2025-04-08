
namespace Global;
public class AddPlannedMaintenanceScheduleControllerDto
{
public DateTime PlannedDate { get; set; }
	public short MaintenanceTypeId { get; set; }
	public int VehicleId { get; set; }
}