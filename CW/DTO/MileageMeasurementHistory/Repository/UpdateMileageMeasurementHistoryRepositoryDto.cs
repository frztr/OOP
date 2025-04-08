
namespace Global;
public class UpdateMileageMeasurementHistoryRepositoryDto
{
    public int Id { get; set; }
    public decimal? KmCount { get; set; }
	public DateTime? MeasurementDate { get; set; }
	public int? VehicleId { get; set; }
}