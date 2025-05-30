
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateCityServiceDto
{
    [Required]
	public int Id { get; set; }
	[StringLength(50)]
	public string? Name { get; set; }
	public short? CountryId { get; set; }
}