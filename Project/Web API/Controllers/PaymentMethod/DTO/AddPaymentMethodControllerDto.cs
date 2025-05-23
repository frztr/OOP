
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddPaymentMethodControllerDto
{
	[Required]
	[StringLength(50)]
	public string Name { get; set; }
}