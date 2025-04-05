using Microsoft.EntityFrameworkCore;

public interface IRepositoryGetById<Key, EntityDto>
where Key : IComparable<Key>
{
    public EntityDto GetById(Key id);
}

public interface IRepositoryGetById<Key, EntityDto, Entity>: IRepositoryGetById<Key, EntityDto>
where Entity : class, IEntity<Key>, IConvertible<EntityDto>
where Key : IComparable<Key>
{
    protected DbSet<Entity> set { get; }

    EntityDto IRepositoryGetById<Key, EntityDto>.GetById(Key id)
    {
        return set.FirstOrDefault(x => x.Id.CompareTo(id) == 0).Convert();
        // return (EntityDto)Activator.CreateInstance(typeof(EntityDto), set.FirstOrDefault(x => x.Id.CompareTo(id) == 0));
    }
}