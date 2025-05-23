
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateBookingRepositoryDto
{
    [Required]
	public long Id { get; set; }
	public long? UserId { get; set; }
	public int? EventId { get; set; }
	public DateTime? BookingDate { get; set; }
	public short? BookingStatusId { get; set; }
	public int? NumberOfSeats { get; set; }
}