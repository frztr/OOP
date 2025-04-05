namespace Global;
public class DocumentType : IEntity<short>
{
    public short Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<VehicleDocument> VehicleDocuments { get; set; }
}