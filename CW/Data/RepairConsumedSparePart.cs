namespace Global;
public class RepairConsumedSparePart
{
    public int Id { get; set; }
    public int RepairId { get; set; }
    public int SparePartId { get; set; }
    public int PartCount { get; set; }
    
    public RepairHistory RepairHistory { get; set; }
    public SparePart SparePart { get; set; }
}