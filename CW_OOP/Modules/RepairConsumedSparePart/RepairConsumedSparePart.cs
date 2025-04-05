namespace Global;
public class RepairConsumedSparePart : IEntity<int>
{
    public int Id { get; set; }
    public int RepairId { get; set; }
    public int SparePartId { get; set; }
    public int PartCount { get; set; }
    
    public RepairHistory Repair { get; set; }
    public SparePart SparePart { get; set; }
}