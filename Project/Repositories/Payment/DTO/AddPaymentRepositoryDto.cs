
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddPaymentRepositoryDto
{
	[Required]
	public long Id { get; set; }
	[Required]
	public long BookingId { get; set; }
	[Required]
	public decimal Amount { get; set; }
	[Required]
	public DateTime PaymentDate { get; set; }
	[Required]
	public short PaymentMethodId { get; set; }
	[Required]
	public short StatusId { get; set; }
}