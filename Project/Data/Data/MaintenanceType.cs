using System.ComponentModel.DataAnnotations;
public class MaintenanceType{
    [Required]
	public short Id { get;set; }
	[StringLength(30)]
	public string Name { get;set; }
	public ICollection<MaintenanceHistory> MaintenanceHistories { get;set; }
	public ICollection<PlannedMaintenanceSchedule> PlannedMaintenanceSchedules { get;set; }
}