
namespace Global;
public class UpdateUserRepositoryDto
{
    public short Id { get; set; }
    public string? Login { get; set; }
	public short? RoleId { get; set; }
	public string? Fio { get; set; }
    public string PasswordHash { get; set; }
}