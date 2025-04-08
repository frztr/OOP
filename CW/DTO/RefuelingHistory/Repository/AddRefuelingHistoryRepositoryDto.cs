
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddRefuelingHistoryRepositoryDto
{
    	public decimal Volume { get; set; }
	[Required]
	public short OilTypeId { get; set; }
	[Required]
	public long FuelStationTinNumber { get; set; }
	[Required]
	public int VehicleId { get; set; }
		public decimal Price { get; set; }
	[Required]
	public DateTime DateTime { get; set; }
	[Required]
	public short DriverId { get; set; }
}