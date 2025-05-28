
namespace Global;
public class FuelMeasurementHistoryRepositoryDto
{
    public int Id { get; set; }
	public decimal Volume { get; set; }
	public DateTime MeasurementDate { get; set; }
	public int VehicleId { get; set; }
}