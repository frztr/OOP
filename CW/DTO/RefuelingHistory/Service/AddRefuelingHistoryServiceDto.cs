
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddRefuelingHistoryServiceDto
{
	[Required]
	public decimal Volume { get; set; }
	[Required]
	public short OilTypeId { get; set; }
	[Required]
	public long FuelstationTinNumber { get; set; }
	[Required]
	public int VehicleId { get; set; }
	[Required]
	public decimal Price { get; set; }
	[Required]
	public DateTime Datetime { get; set; }
	[Required]
	public short DriverId { get; set; }
}