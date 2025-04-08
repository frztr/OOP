
namespace Global;
public class UpdateRepairConsumedSparePartControllerDto
{
    public int Id { get; set; }
    public int? RepairId { get; set; }
	public int? SparePartId { get; set; }
	public int? PartCount { get; set; }
}