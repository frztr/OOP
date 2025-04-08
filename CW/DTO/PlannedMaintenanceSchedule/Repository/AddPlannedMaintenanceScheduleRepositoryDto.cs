
namespace Global;
public class AddPlannedMaintenanceScheduleRepositoryDto
{
public DateTime PlannedDate { get; set; }
	public short MaintenanceTypeId { get; set; }
	public int VehicleId { get; set; }
}