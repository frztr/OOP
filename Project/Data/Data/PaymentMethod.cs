using System.ComponentModel.DataAnnotations;
public class PaymentMethod{
    [Required]
	public short Id { get;set; }
	[StringLength(50)]
	public string Name { get;set; }
	public ICollection<Payment> Payments { get;set; }
}