
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddRepairConsumedSparePartControllerDto
{
    [Required]
	public int RepairId { get; set; }
	[Required]
	public int SparePartId { get; set; }
	[Required]
	public int PartCount { get; set; }
}