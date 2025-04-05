using Role.DTO;

namespace Global;
public class Role : IEntity<short>, IConvertible<EntityRepositoryDto>
{
    public short Id { get; set; }
    public string Name { get; set; }
    public ICollection<User> Users { get; set; }

    public EntityRepositoryDto Convert()
    {
        return new EntityRepositoryDto(){
            Id = Id,
            Name = Name
        };
    }
}