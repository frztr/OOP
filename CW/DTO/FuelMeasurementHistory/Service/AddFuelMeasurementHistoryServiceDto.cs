
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddFuelMeasurementHistoryServiceDto
{
	public decimal? Volume { get; set; }
	[Required]
	public DateTime MeasurementDate { get; set; }
	[Required]
	public int VehicleId { get; set; }
}