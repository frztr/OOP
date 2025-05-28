using System.ComponentModel.DataAnnotations;
public class PlannedMaintenanceSchedule{
    [Required]
	public int Id { get;set; }
	public DateTime PlannedDate { get;set; }
	public short MaintenanceTypeId { get;set; }
	public MaintenanceType MaintenanceType {get;set;}
	public int VehicleId { get;set; }
	public Vehicle Vehicle {get;set;}
}