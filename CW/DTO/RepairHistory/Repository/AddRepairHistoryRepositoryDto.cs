
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddRepairHistoryRepositoryDto
{
	[Required]
	public int VehicleId { get; set; }
	[Required]
	public DateTime DatetimeBegin { get; set; }
	public DateTime? DatetimeEnd { get; set; }
	[Required]
	[StringLength(2000)]
	public string CompletedWork { get; set; }
	public decimal? Price { get; set; }
	public long? ServicestationTinNumber { get; set; }
	public short? AutomechanicId { get; set; }
}