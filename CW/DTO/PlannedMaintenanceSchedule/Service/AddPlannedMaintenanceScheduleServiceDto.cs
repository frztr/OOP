
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddPlannedMaintenanceScheduleServiceDto
{
	[Required]
	public DateTime PlannedDate { get; set; }
	[Required]
	public short MaintenanceTypeId { get; set; }
	[Required]
	public int VehicleId { get; set; }
}