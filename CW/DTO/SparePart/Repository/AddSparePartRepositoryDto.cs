
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddSparePartRepositoryDto
{
	[Required]
	[StringLength(100)]
	public string Name { get; set; }
	public int? CountLeft { get; set; }
}