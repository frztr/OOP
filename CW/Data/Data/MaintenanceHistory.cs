using System.ComponentModel.DataAnnotations;
public class MaintenanceHistory{
    [Required]
	public int Id { get;set; }
	public DateTime Date { get;set; }
	public int VehicleId { get;set; }
	public Vehicle Vehicle {get;set;}
	public short MaintenanceTypeId { get;set; }
	public MaintenanceType MaintenanceType {get;set;}
	[StringLength(2000)]
	public string CompletedWork { get;set; }
	public short AutomechanicId { get;set; }
	public Automechanic Automechanic {get;set;}
}