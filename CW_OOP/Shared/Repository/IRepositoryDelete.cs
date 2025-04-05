using Global;
using Microsoft.EntityFrameworkCore;

public interface IRepositoryDelete<Key>
where Key : IComparable<Key>
{
    public void Delete(Key id);
}

public interface IRepositoryDelete<Key, Entity> :
IRepositoryDelete<Key>
where Entity : class, IEntity<Key>
where Key : IComparable<Key>
{
    protected DbSet<Entity> set { get; }

    protected AppDbContext db { get; }
    void IRepositoryDelete<Key>.Delete(Key id)
    {
        set.Remove(set.FirstOrDefault(x => x.Id.CompareTo(id) == 0));
        db.SaveChanges();
    }
}