using System.ComponentModel.DataAnnotations;
public class RepairConsumedSparePart{
    [Required]
	public int Id { get;set; }
	public int RepairId { get;set; }
	public RepairHistory RepairHistory {get;set;}
	public int SparePartId { get;set; }
	public SparePart SparePart {get;set;}
	public int PartCount { get;set; }
}