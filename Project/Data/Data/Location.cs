using System.ComponentModel.DataAnnotations;
public class Location{
    [Required]
	public short Id { get;set; }
	[StringLength(50)]
	public string Name { get;set; }
	[StringLength(100)]
	public string? Address { get;set; }
	public int? NumberOfSeats { get;set; }
	public ICollection<Event> Events { get;set; }
}