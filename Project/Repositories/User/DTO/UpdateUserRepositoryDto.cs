
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateUserRepositoryDto
{

    [Required]
    public long Id { get; set; }

	[StringLength(50)]
	public string? FirstName { get; set; }
	[StringLength(50)]
	public string? LastName { get; set; }
	[StringLength(20)]
	public string? Patronymic { get; set; }
	[StringLength(100)]
	public string? Email { get; set; }
	[StringLength(20)]
	public string? Phone { get; set; }
	public short? RoleId { get; set; }
    public string? PasswordHash { get; set; }
}