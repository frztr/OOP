
namespace Global;
public class PlannedMaintenanceScheduleServiceDto
{
    public int Id { get; set; }
	public DateTime PlannedDate { get; set; }
	public short MaintenanceTypeId { get; set; }
	public int VehicleId { get; set; }
}