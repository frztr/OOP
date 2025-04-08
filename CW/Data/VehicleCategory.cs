namespace Global;
public class VehicleCategory
{
    public short Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<VehicleModel> VehicleModels { get; set; }
}