
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateRepairHistoryServiceDto
{
    [Required]
    	public int Id { get; set; }
    
    	public int VehicleId { get; set; }
		public DateTime DateTimeBegin { get; set; }
		public DateTime DateTimeEnd { get; set; }
		[StringLength(2000)]
	public string CompletedWork { get; set; }
}