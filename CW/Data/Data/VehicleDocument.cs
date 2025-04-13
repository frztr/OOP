using System.ComponentModel.DataAnnotations;
public class VehicleDocument{
    [Required]
	public int Id { get;set; }
	public short DoctypeId { get;set; }
	public DocumentType DocumentType {get;set;}
	[StringLength(255)]
	public string Src { get;set; }
	public int VehicleId { get;set; }
	public Vehicle Vehicle {get;set;}
}