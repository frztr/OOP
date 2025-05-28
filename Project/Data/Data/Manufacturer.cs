using System.ComponentModel.DataAnnotations;
public class Manufacturer{
    [Required]
	public short Id { get;set; }
	[StringLength(20)]
	public string Name { get;set; }
	public ICollection<VehicleModel> VehicleModels { get;set; }
}