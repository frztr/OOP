
namespace Global;
public class PaymentServiceDto
{
    public long Id { get; set; }
	public long BookingId { get; set; }
	public DateTime PaymentDate { get; set; }
	public short PaymentMethodId { get; set; }
	public short StatusId { get; set; }
}