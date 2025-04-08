
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddRepairHistoryRepositoryDto
{
    [Required]
	public int VehicleId { get; set; }
	[Required]
	public DateTime DateTimeBegin { get; set; }
		public DateTime DateTimeEnd { get; set; }
	[Required]
	[StringLength(2000)]
	public string CompletedWork { get; set; }
}