namespace Global;
public class DocumentType
{
    public short Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<VehicleDocument> VehicleDocuments { get; set; }
}