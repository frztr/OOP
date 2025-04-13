using System.ComponentModel.DataAnnotations;
public class VehicleCategory{
    [Required]
	public short Id { get;set; }
	[StringLength(25)]
	public string Name { get;set; }
	public ICollection<VehicleModel> VehicleModels { get;set; }
}