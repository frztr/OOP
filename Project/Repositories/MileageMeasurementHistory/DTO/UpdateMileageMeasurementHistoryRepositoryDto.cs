
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateMileageMeasurementHistoryRepositoryDto
{
    [Required]
	public int Id { get; set; }
	public decimal? KmCount { get; set; }
	public DateTime? MeasurementDate { get; set; }
	public int? VehicleId { get; set; }
}