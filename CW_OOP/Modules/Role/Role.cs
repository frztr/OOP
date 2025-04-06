using Role.DTO;

namespace Global;
public class Role : IEntity<short>
{
    public short Id { get; set; }
    public string Name { get; set; }
    public ICollection<User> Users { get; set; }
}