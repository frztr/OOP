
namespace Global;
public class AddUserRepositoryDto
{
public string Login { get; set; }
	public short RoleId { get; set; }
	public string Fio { get; set; }
    public string PasswordHash { get; set; }
}