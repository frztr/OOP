
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddFuelTypeRepositoryDto
{
	[Required]
	[StringLength(20)]
	public string Name { get; set; }
}