namespace Global;
public class MaintenanceType : IEntity<short>
{
    public short Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<MaintenanceHistory> MaintenanceHistories { get; set; }
    public ICollection<PlannedMaintenanceSchedule> PlannedMaintenances { get; set; }
}