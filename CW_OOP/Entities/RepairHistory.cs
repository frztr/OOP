namespace Global;
public class RepairHistory : IEntity<int>
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public DateTime DateTime { get; set; }
    public string CompletedWork { get; set; }
    public decimal? Price { get; set; }
    public long? ServiceStationTinNumber { get; set; }
    public int? AutomechanicId { get; set; }
    
    public Vehicle Vehicle { get; set; }
    public Automechanic Automechanic { get; set; }
    public ICollection<RepairConsumedSparePart> ConsumedSpareParts { get; set; }
}