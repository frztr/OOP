
namespace Global;
public class UpdateFuelMeasurementHistoryControllerDto
{
    public int Id { get; set; }
    public decimal? Volume { get; set; }
	public DateTime? MeasurementDate { get; set; }
	public int? VehicleId { get; set; }
}