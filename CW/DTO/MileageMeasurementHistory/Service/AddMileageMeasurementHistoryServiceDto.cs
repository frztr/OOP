
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddMileageMeasurementHistoryServiceDto
{
    	public decimal KmCount { get; set; }
	[Required]
	public DateTime MeasurementDate { get; set; }
	[Required]
	public int VehicleId { get; set; }
}