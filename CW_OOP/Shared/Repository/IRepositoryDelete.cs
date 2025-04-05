using Global;
using Microsoft.EntityFrameworkCore;

public interface IIRepositoryDelete<Key>
where Key : IComparable<Key>
{
    public void Delete(Key id);
}

public interface IRepositoryDelete<Key, Entity> :
IIRepositoryDelete<Key>
where Entity : class, IEntity<Key>
where Key : IComparable<Key>
{
    protected DbSet<Entity> set { get; }

    protected AppDbContext db { get; }
    void IIRepositoryDelete<Key>.Delete(Key id)
    {
        set.Remove(set.FirstOrDefault(x => x.Id.CompareTo(id) == 0));
        db.SaveChanges();
    }
}