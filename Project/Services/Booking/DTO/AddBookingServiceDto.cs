
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddBookingServiceDto
{
	[Required]
	public long Id { get; set; }
	[Required]
	public long UserId { get; set; }
	[Required]
	public int EventId { get; set; }
	[Required]
	public DateTime BookingDate { get; set; }
	public short? BookingStatusId { get; set; }
	public int NumberOfSeats { get; set; }
}