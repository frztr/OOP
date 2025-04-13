using System.ComponentModel.DataAnnotations;
public class OilType{
    [Required]
	public short Id { get;set; }
	[StringLength(10)]
	public string Name { get;set; }
	public short FuelTypeId { get;set; }
	public FuelType FuelType {get;set;}
	public ICollection<RefuelingHistory> RefuelingHistories { get;set; }
}