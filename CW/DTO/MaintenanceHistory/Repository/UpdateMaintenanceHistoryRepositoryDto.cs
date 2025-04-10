
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateMaintenanceHistoryRepositoryDto
{
    [Required]
	public int Id { get; set; }
    
    	public DateTime? Date { get; set; }
	public int? VehicleId { get; set; }
	public short? MaintenanceTypeId { get; set; }
[StringLength(2000)]
	public string? CompletedWork { get; set; }
	public short? AutomechanicId { get; set; }
}