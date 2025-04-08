
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddPlannedMaintenanceScheduleControllerDto
{
    [Required]
	public DateTime PlannedDate { get; set; }
	[Required]
	public short MaintenanceTypeId { get; set; }
	[Required]
	public int VehicleId { get; set; }
}