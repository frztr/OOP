using System.ComponentModel.DataAnnotations;
public class SparePart{
    [Required]
	public int Id { get;set; }
	[StringLength(100)]
	public string Name { get;set; }
	public int CountLeft { get;set; }
	public ICollection<RepairConsumedSparePart> RepairConsumedSpareParts { get;set; }
}