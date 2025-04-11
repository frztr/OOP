
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateRefuelingHistoryControllerDto
{
    [Required]
	public int Id { get; set; }
	public decimal? Volume { get; set; }
	public short? OilTypeId { get; set; }
	public long? FuelStationTinNumber { get; set; }
	public int? VehicleId { get; set; }
	public decimal? Price { get; set; }
	public DateTime? DateTime { get; set; }
	public short? DriverId { get; set; }
}