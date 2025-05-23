using System.ComponentModel.DataAnnotations;
public class BookingStatus{
    [Required]
	public short Id { get;set; }
	[StringLength(50)]
	public string Name { get;set; }
	public ICollection<Booking> Bookings { get;set; }
}