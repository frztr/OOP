
namespace Global;
public class PlannedMaintenanceScheduleControllerDto
{
    public int Id { get; set; }
	public DateTime PlannedDate { get; set; }
	public short MaintenanceTypeId { get; set; }
	public int VehicleId { get; set; }
}