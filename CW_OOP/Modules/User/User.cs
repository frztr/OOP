namespace Global;
public class User : IEntity<short>
{
    public short Id { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public short RoleId { get; set; }

    public Role Role { get; set; }
    public Employee Employee { get; set; }
}