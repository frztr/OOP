using System.ComponentModel.DataAnnotations;
public class RepairHistory{
    [Required]
	public int Id { get;set; }
	public int VehicleId { get;set; }
	public Vehicle Vehicle {get;set;}
	public DateTime DatetimeBegin { get;set; }
	public DateTime? DatetimeEnd { get;set; }
	[StringLength(2000)]
	public string CompletedWork { get;set; }
	public decimal? Price { get;set; }
	public long? ServicestationTinNumber { get;set; }
	public short? AutomechanicId { get;set; }
	public Automechanic Automechanic {get;set;}
	public ICollection<RepairConsumedSparePart> RepairConsumedSpareParts { get;set; }
}