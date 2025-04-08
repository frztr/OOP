
namespace Global;
public class UpdateUserServiceDto
{
    public short Id { get; set; }
    public string? Login { get; set; }
	public short? RoleId { get; set; }
	public string? Fio { get; set; }
    public string Password { get; set; }
}