
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddPaymentMethodServiceDto
{
	[Required]
	[StringLength(50)]
	public string Name { get; set; }
}