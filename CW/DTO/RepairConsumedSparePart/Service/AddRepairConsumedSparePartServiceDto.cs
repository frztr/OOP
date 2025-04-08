
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddRepairConsumedSparePartServiceDto
{
    [Required]
	public int RepairId { get; set; }
	[Required]
	public int SparePartId { get; set; }
	[Required]
	public int PartCount { get; set; }
}