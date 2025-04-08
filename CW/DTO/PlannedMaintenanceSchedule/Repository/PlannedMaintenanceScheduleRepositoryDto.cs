
namespace Global;
public class PlannedMaintenanceScheduleRepositoryDto
{
    public int Id { get; set; }
	public DateTime PlannedDate { get; set; }
	public short MaintenanceTypeId { get; set; }
	public int VehicleId { get; set; }
}