namespace Global;
public class SparePart
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CountLeft { get; set; }
    
    public ICollection<RepairConsumedSparePart> RepairConsumptions { get; set; }
}