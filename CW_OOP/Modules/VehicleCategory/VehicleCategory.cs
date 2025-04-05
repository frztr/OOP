namespace Global;
public class VehicleCategory : IEntity<short>
{
    public short Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<VehicleModel> VehicleModels { get; set; }
}