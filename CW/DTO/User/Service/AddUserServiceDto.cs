
using System.ComponentModel.DataAnnotations;
namespace Global;
public class AddUserServiceDto
{
    [Required]
	[StringLength(32)]
	public string Login { get; set; }
	[Required]
	public short RoleId { get; set; }
	[Required]
	[StringLength(100)]
	public string Fio { get; set; }
    [Required]
    public string Password { get; set; }
}