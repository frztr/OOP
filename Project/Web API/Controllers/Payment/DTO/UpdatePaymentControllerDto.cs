
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdatePaymentControllerDto
{
    [Required]
	public long Id { get; set; }
	public long? BookingId { get; set; }
	public decimal? Amount { get; set; }
	public DateTime? PaymentDate { get; set; }
	public short? PaymentMethodId { get; set; }
	public short? StatusId { get; set; }
}