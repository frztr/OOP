
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddPaymentStatusRepositoryDto
{
	[Required]
	[StringLength(50)]
	public string Name { get; set; }
}