namespace Global;
public class RefuelingHistory
{
    public int Id { get; set; }
    public decimal Volume { get; set; }
    public short OilTypeId { get; set; }
    public long FuelStationTinNumber { get; set; }
    public int VehicleId { get; set; }
    public decimal Price { get; set; }
    public DateTime DateTime { get; set; }
    public short DriverId { get; set; }
    
    public OilType OilType { get; set; }
    public Vehicle Vehicle { get; set; }
    public Driver Driver { get; set; }
}