
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateRepairHistoryControllerDto
{
    [Required]
	public int Id { get; set; }
	public int? VehicleId { get; set; }
	public DateTime? DateTimeBegin { get; set; }
	public DateTime? DateTimeEnd { get; set; }
	[StringLength(2000)]
	public string? CompletedWork { get; set; }
	public decimal? Price { get; set; }
	public long? ServiceStationTinNumber { get; set; }
	public short? AutomechanicId { get; set; }
}