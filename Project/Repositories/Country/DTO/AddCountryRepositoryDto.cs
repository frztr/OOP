
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddCountryRepositoryDto
{
	[Required]
	[StringLength(50)]
	public string Name { get; set; }
}