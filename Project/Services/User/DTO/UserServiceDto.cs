
namespace Global;
public class UserServiceDto
{
    public long Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string? Patronymic { get; set; }
	public string Email { get; set; }
	public string Phone { get; set; }
	public short? RoleId { get; set; }
}