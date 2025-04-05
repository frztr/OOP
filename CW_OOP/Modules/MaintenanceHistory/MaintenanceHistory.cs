namespace Global;
public class MaintenanceHistory : IEntity<int>
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int VehicleId { get; set; }
    public short MaintenanceTypeId { get; set; }
    public string CompletedWork { get; set; }
    public short AutomechanicId { get; set; }
    
    public Vehicle Vehicle { get; set; }
    public MaintenanceType MaintenanceType { get; set; }
    public Automechanic Automechanic { get; set; }
}