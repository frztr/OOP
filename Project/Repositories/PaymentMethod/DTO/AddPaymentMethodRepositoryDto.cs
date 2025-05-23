
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddPaymentMethodRepositoryDto
{
	[Required]
	[StringLength(50)]
	public string Name { get; set; }
}