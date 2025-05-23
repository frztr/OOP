
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddBookingStatusRepositoryDto
{
	[Required]
	[StringLength(50)]
	public string Name { get; set; }
}