
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddBookingStatusControllerDto
{
	[Required]
	[StringLength(50)]
	public string Name { get; set; }
}