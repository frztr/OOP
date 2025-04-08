namespace Global;
public class OilType
{
    public short Id { get; set; }
    public string Name { get; set; }
    public short FuelTypeId { get; set; }
    
    public FuelType FuelType { get; set; }
    public ICollection<RefuelingHistory> Refuelings { get; set; }
}