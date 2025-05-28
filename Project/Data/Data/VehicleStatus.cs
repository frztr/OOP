using System.ComponentModel.DataAnnotations;
public class VehicleStatus{
    [Required]
	public short Id { get;set; }
	[StringLength(20)]
	public string Name { get;set; }
	public ICollection<Vehicle> Vehicles { get;set; }
}