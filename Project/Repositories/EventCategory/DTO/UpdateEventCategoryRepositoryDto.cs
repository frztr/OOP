
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateEventCategoryRepositoryDto
{
    [Required]
	public short Id { get; set; }
	[StringLength(50)]
	public string? Name { get; set; }
}