
namespace Global;
public class UserControllerDto
{
    public long Id { get; set; }
	public string Login { get; set; }
	public string Email { get; set; }
	public string? Firstname { get; set; }
	public string? Lastname { get; set; }
	public DateTime? BirthDate { get; set; }
	public string? Bio { get; set; }
	public int? CityId { get; set; }
	public short RoleId { get; set; }
	public string? WebsiteUrl { get; set; }
	public string? AvatarUrl { get; set; }
	public DateTime? RegistrationDate { get; set; }
	public DateTime? LastLogin { get; set; }
}