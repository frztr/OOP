
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddPaymentStatusServiceDto
{
	[Required]
	[StringLength(50)]
	public string Name { get; set; }
}