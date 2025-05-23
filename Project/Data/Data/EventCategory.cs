using System.ComponentModel.DataAnnotations;
public class EventCategory{
    [Required]
	public short Id { get;set; }
	[StringLength(50)]
	public string Name { get;set; }
	public ICollection<Event> Events { get;set; }
}