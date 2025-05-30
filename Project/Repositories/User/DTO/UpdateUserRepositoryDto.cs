
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateUserRepositoryDto
{

    [Required]
    public long Id { get; set; }

	[StringLength(20)]
	public string? Login { get; set; }
	[StringLength(40)]
	public string? Email { get; set; }
	[StringLength(50)]
	public string? Firstname { get; set; }
	[StringLength(50)]
	public string? Lastname { get; set; }
	public DateTime? BirthDate { get; set; }
	[StringLength(12004)]
	public string? Bio { get; set; }
	public int? CityId { get; set; }
	public short? RoleId { get; set; }
	[StringLength(255)]
	public string? WebsiteUrl { get; set; }
	[StringLength(300)]
	public string? AvatarUrl { get; set; }
	public DateTime? RegistrationDate { get; set; }
	public DateTime? LastLogin { get; set; }
    public string? PasswordHash { get; set; }
}