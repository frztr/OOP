
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddEventCategoryServiceDto
{
	[Required]
	[StringLength(50)]
	public string Name { get; set; }
}