
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddLocationRepositoryDto
{
	[Required]
	[StringLength(50)]
	public string Name { get; set; }
	[StringLength(100)]
	public string? Address { get; set; }
	public int? NumberOfSeats { get; set; }
}