namespace Global;
public class VehiclePhoto : IEntity<int>
{
    public int Id { get; set; }
    public string Src { get; set; }
    public int VehicleId { get; set; }
    
    public Vehicle Vehicle { get; set; }
}