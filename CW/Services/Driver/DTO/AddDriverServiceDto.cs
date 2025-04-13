
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddDriverServiceDto
{
	// [Required]
	// public short UserId { get; set; }
	[Required]
	public long DriverLicense { get; set; }
	[Required]
	public short Experience { get; set; }

	[Required]
	[StringLength(32)]
	public string Login { get; set; }
	[Required]
	[StringLength(100)]
	public string Fio { get; set; }
	// [Required]
	// public short RoleId { get; set; }
    [Required]
    public string Password { get; set; }
}