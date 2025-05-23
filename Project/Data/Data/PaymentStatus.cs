using System.ComponentModel.DataAnnotations;
public class PaymentStatus{
    [Required]
	public short Id { get;set; }
	[StringLength(50)]
	public string Name { get;set; }
	public ICollection<Payment> Payments { get;set; }
}