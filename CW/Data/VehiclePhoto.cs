namespace Global;
public class VehiclePhoto
{
    public int Id { get; set; }
    public string Src { get; set; }
    public int VehicleId { get; set; }
    
    public Vehicle Vehicle { get; set; }
}