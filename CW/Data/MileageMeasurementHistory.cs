namespace Global;
public class MileageMeasurementHistory
{
    public int Id { get; set; }
    public decimal KmCount { get; set; }
    public DateTime MeasurementDate { get; set; }
    public int VehicleId { get; set; }
    
    public Vehicle Vehicle { get; set; }
}