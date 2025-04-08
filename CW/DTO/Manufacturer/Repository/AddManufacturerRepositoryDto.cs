
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddManufacturerRepositoryDto
{
    [Required]
	[StringLength(20)]
	public string Name { get; set; }
}