
namespace Global;
public class RepairConsumedSparePartRepositoryDto
{
    public int Id { get; set; }
	public int RepairId { get; set; }
	public int SparePartId { get; set; }
	public int PartCount { get; set; }
}