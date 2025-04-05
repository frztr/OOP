using Role.DTO;

namespace Global;
public class Role : IEntity<short>, IConvertible<EntityDto>
{
    public short Id { get; set; }
    public string Name { get; set; }
    public ICollection<User> Users { get; set; }

    public EntityDto Convert()
    {
        return new EntityDto(){
            Id = Id,
            Name = Name
        };
    }
}