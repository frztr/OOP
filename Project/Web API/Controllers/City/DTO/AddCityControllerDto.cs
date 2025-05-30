
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddCityControllerDto
{
	[Required]
	[StringLength(50)]
	public string Name { get; set; }
	[Required]
	public short CountryId { get; set; }
}