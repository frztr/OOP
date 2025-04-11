
namespace Global;
public class MileageMeasurementHistoryControllerDto
{
    public int Id { get; set; }
	public decimal? KmCount { get; set; }
	public DateTime MeasurementDate { get; set; }
	public int VehicleId { get; set; }
}