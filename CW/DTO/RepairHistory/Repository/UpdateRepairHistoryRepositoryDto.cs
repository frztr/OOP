
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateRepairHistoryRepositoryDto
{
    [Required]
	public int Id { get; set; }
	public int? VehicleId { get; set; }
	public DateTime? DateTimeBegin { get; set; }
	[StringLength(2000)]
	public string? CompletedWork { get; set; }
}