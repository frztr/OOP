using System.ComponentModel.DataAnnotations;
public class RefuelingHistory{
    [Required]
	public int Id { get;set; }
	public decimal Volume { get;set; }
	public short OilTypeId { get;set; }
	public OilType OilType {get;set;}
	public long FuelstationTinNumber { get;set; }
	public int VehicleId { get;set; }
	public Vehicle Vehicle {get;set;}
	public decimal Price { get;set; }
	public DateTime Datetime { get;set; }
	public short DriverId { get;set; }
	public Driver Driver {get;set;}
}