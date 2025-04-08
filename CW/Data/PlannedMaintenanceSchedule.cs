namespace Global;
public class PlannedMaintenanceSchedule
{
    public int Id { get; set; }
    public DateTime PlannedDate { get; set; }
    public short MaintenanceTypeId { get; set; }
    public int VehicleId { get; set; }
    
    public MaintenanceType MaintenanceType { get; set; }
    public Vehicle Vehicle { get; set; }
}