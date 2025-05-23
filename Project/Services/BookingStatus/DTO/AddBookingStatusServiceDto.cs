
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddBookingStatusServiceDto
{
	[Required]
	[StringLength(50)]
	public string Name { get; set; }
}