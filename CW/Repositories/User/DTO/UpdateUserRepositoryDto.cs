
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateUserRepositoryDto
{

    [Required]
    public short Id { get; set; }

	[StringLength(32)]
	public string? Login { get; set; }
	[StringLength(100)]
	public string? Fio { get; set; }
	public short? RoleId { get; set; }
    public string? PasswordHash { get; set; }
}