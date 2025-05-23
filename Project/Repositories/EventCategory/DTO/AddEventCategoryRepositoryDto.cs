
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddEventCategoryRepositoryDto
{
	[Required]
	[StringLength(50)]
	public string Name { get; set; }
}