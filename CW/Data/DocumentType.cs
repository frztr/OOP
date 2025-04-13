using System.ComponentModel.DataAnnotations;
public class DocumentType{
    [Required]
	public short Id { get;set; }
	[StringLength(20)]
	public string Name { get;set; }
	public ICollection<VehicleDocument> VehicleDocuments { get;set; }
}