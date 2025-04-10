
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateDriverControllerDto
{
    [Required]
	public short UserId { get; set; }
    
    	public long? DriverLicense { get; set; }
	public short? Experience { get; set; }
}