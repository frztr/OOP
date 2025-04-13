
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddMaintenanceHistoryServiceDto
{
	[Required]
	public DateTime Date { get; set; }
	[Required]
	public int VehicleId { get; set; }
	[Required]
	public short MaintenanceTypeId { get; set; }
	[Required]
	[StringLength(2000)]
	public string CompletedWork { get; set; }
	[Required]
	public short AutomechanicId { get; set; }
}