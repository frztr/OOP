namespace Global;
public class Role
{
    public short Id { get; set; }
    public string Name { get; set; }
    public ICollection<User> Users { get; set; }
}