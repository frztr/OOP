namespace Global;
public class VehicleDocument
{
    public int Id { get; set; }
    public short DocTypeId { get; set; }
    public string Src { get; set; }
    public int VehicleId { get; set; }
    
    public DocumentType DocumentType { get; set; }
    public Vehicle Vehicle { get; set; }
}