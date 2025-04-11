
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateUserServiceDto
{

    [Required]
    public short Id { get; set; }

	[StringLength(32)]
	public string? Login { get; set; }
	public short? RoleId { get; set; }
	[StringLength(100)]
	public string? Fio { get; set; }
    public string? Password { get; set; }
}