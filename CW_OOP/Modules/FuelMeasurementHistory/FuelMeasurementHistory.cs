
namespace Global;
public class FuelMeasurementHistory : IEntity<int>
{
    public int Id { get; set; }
    public decimal Volume { get; set; }
    public DateTime MeasurementDate { get; set; }
    public int VehicleId { get; set; }
    
    public Vehicle Vehicle { get; set; }
}