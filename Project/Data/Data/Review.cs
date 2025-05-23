using System.ComponentModel.DataAnnotations;
public class Review{
    [Required]
	public long Id { get;set; }
	public long UserId { get;set; }
	public User User {get;set;}
	public short EventId { get;set; }
	public Event Event {get;set;}
	public short Rating { get;set; }
	[StringLength(500)]
	public string? Comment { get;set; }
	public DateTime? ReviewDate { get;set; }
}