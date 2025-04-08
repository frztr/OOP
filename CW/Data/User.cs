namespace Global;
public class User
{
    public short Id { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public short RoleId { get; set; }

    public string Fio { get; set; }

    public Role Role { get; set; }
    public Driver Driver { get; set; }

    public Automechanic Automechanic { get; set; }
}