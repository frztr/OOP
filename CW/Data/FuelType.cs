namespace Global;
public class FuelType
{
    public short Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<VehicleModel> VehicleModels { get; set; }
    public ICollection<OilType> OilTypes { get; set; }
}