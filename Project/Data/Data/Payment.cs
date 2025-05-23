using System.ComponentModel.DataAnnotations;
public class Payment{
    [Required]
	public long Id { get;set; }
	public long BookingId { get;set; }
	public Booking Booking {get;set;}
	public numeric(10, Amount { get;set; }
	public DateTime PaymentDate { get;set; }
	public short PaymentMethodId { get;set; }
	public PaymentMethod PaymentMethod {get;set;}
	public short StatusId { get;set; }
	public PaymentStatus PaymentStatus {get;set;}
}