
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddCountryControllerDto
{
	[Required]
	[StringLength(50)]
	public string Name { get; set; }
}