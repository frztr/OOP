
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddDriverControllerDto
{
	[Required]
	public short UserId { get; set; }
	[Required]
	public long DriverLicense { get; set; }
	[Required]
	public short Experience { get; set; }
}