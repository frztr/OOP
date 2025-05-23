
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddEventCategoryControllerDto
{
	[Required]
	[StringLength(50)]
	public string Name { get; set; }
}