using System.ComponentModel.DataAnnotations;
public class Booking{
    [Required]
	public long Id { get;set; }
	public long UserId { get;set; }
	public User User {get;set;}
	public int EventId { get;set; }
	public Event Event {get;set;}
	public DateTime BookingDate { get;set; }
	public short? BookingStatusId { get;set; }
	public BookingStatus BookingStatus {get;set;}
	public int NumberOfSeats { get;set; }
	public ICollection<Payment> Payments { get;set; }
}