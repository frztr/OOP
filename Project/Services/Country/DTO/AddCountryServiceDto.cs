
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddCountryServiceDto
{
	[Required]
	[StringLength(50)]
	public string Name { get; set; }
}