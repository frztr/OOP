
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateRepairConsumedSparePartRepositoryDto
{
    [Required]
	public int Id { get; set; }
	public int? RepairId { get; set; }
	public int? SparePartId { get; set; }
	public int? PartCount { get; set; }
}