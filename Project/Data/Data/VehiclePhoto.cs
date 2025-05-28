using System.ComponentModel.DataAnnotations;
public class VehiclePhoto{
    [Required]
	public int Id { get;set; }
	[StringLength(255)]
	public string Src { get;set; }
	public int VehicleId { get;set; }
	public Vehicle Vehicle {get;set;}
}