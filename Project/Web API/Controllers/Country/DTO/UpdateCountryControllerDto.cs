
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateCountryControllerDto
{
    [Required]
	public short Id { get; set; }
	[StringLength(50)]
	public string? Name { get; set; }
}