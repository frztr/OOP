using System.ComponentModel.DataAnnotations;
public class MileageMeasurementHistory{
    [Required]
	public int Id { get;set; }
	public decimal KmCount { get;set; }
	public DateTime MeasurementDate { get;set; }
	public int VehicleId { get;set; }
	public Vehicle Vehicle {get;set;}
}