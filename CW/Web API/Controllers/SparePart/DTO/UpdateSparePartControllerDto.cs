
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateSparePartControllerDto
{
    [Required]
	public int Id { get; set; }
	[StringLength(100)]
	public string? Name { get; set; }
	public int? CountLeft { get; set; }
}