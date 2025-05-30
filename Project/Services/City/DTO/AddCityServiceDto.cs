
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddCityServiceDto
{
	[Required]
	[StringLength(50)]
	public string Name { get; set; }
	[Required]
	public short CountryId { get; set; }
}