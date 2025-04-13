
namespace Global;
public class RefuelingHistoryControllerDto
{
    public int Id { get; set; }
	public decimal Volume { get; set; }
	public short OilTypeId { get; set; }
	public long FuelstationTinNumber { get; set; }
	public int VehicleId { get; set; }
	public decimal Price { get; set; }
	public DateTime Datetime { get; set; }
	public short DriverId { get; set; }
}