using System.ComponentModel.DataAnnotations;
public class FuelType{
    [Required]
	public short Id { get;set; }
	[StringLength(20)]
	public string Name { get;set; }
	public ICollection<VehicleModel> VehicleModels { get;set; }
	public ICollection<OilType> OilTypes { get;set; }
}