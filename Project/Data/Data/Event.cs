using System.ComponentModel.DataAnnotations;
public class Event{
    [Required]
	public int Id { get;set; }
	[StringLength(50)]
	public string Title { get;set; }
	[StringLength(300)]
	public string Description { get;set; }
	public short LocationId { get;set; }
	public Location Location {get;set;}
	public DateTime StartTime { get;set; }
	public DateTime EndTime { get;set; }
	public long CreatedBy { get;set; }
	public User User {get;set;}
	public short EventCategoryId { get;set; }
	public EventCategory EventCategory {get;set;}
	public ICollection<Booking> Bookings { get;set; }
	public ICollection<Review> Reviews { get;set; }
}