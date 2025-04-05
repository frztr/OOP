using Global;
using Microsoft.EntityFrameworkCore;
public interface IIRepositoryUpdate<UpdateDto>
{
    public void Update(UpdateDto updateDto);
}

public interface IRepositoryUpdate<UpdateDto, Entity, Key> : IIRepositoryUpdate<UpdateDto>
where Entity : class, IEntity<Key>
where UpdateDto : IUpdateDto<Key, Entity>
where Key : IComparable<Key>
{
    protected DbSet<Entity> set { get; }

    protected AppDbContext db { get; }
    void IIRepositoryUpdate<UpdateDto>.Update(UpdateDto updateDto)
    {
        var entity = set.FirstOrDefault(x => x.Id.CompareTo(updateDto.Id) == 0);
        updateDto.Update(entity);
        db.SaveChanges();
    }
}