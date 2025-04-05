using Driver.DTO;
using Global;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public interface IBaseRepository<Key, AddDto, UpdateDto, EntityDto> :
IRepositoryAdd<AddDto>,
IRepositoryDelete<Key>,
IRepositoryGetAll<EntityDto>,
IRepositoryGetById<Key, EntityDto>,
IRepositoryUpdate<UpdateDto>
where Key : IComparable<Key>
{

}
public interface IBaseRepository<Key, Entity, AddDto, UpdateDto, EntityDto> :
IBaseRepository<Key, AddDto, UpdateDto, EntityDto>,
IRepositoryAdd<AddDto, Entity>,
IRepositoryDelete<Key, Entity>,
IRepositoryGetAll<EntityDto, Entity>,
IRepositoryGetById<Key, EntityDto, Entity>,
IRepositoryUpdate<UpdateDto, Entity, Key>
where Key : IComparable<Key>
where Entity : class, IEntity<Key>, IConvertible<EntityDto>
where AddDto : IConvertible<Entity>
where UpdateDto : IUpdateDto<Key, Entity>
{
    protected AppDbContext db { get; }

    protected DbSet<Entity> set { get; }

    AppDbContext IRepositoryAdd<AddDto, Entity>.db => db;

    AppDbContext IRepositoryDelete<Key, Entity>.db => db;

    AppDbContext IRepositoryUpdate<UpdateDto, Entity, Key>.db => db;

    DbSet<Entity> IRepositoryAdd<AddDto, Entity>.set => set;

    DbSet<Entity> IRepositoryDelete<Key, Entity>.set => set;

    DbSet<Entity> IRepositoryGetAll<EntityDto, Entity>.set => set;

    DbSet<Entity> IRepositoryGetById<Key, EntityDto, Entity>.set => set;

    DbSet<Entity> IRepositoryUpdate<UpdateDto, Entity, Key>.set => set;
}

public abstract class BaseRepository<Key, Entity, AddDto, UpdateDto, EntityDto> :
IBaseRepository<Key, Entity, AddDto, UpdateDto, EntityDto>
where Key : IComparable<Key>
where Entity : class, IEntity<Key>, IConvertible<EntityDto>
where AddDto : IConvertible<Entity>
where UpdateDto : IUpdateDto<Key, Entity>
{
    private AppDbContext db;
    private DbSet<Entity> set;
    public BaseRepository(AppDbContext db)
    {
        this.db = db;
        this.set = db.Set<Entity>();
    }
    AppDbContext IBaseRepository<Key, Entity, AddDto, UpdateDto, EntityDto>.db => db;

    DbSet<Entity> IBaseRepository<Key, Entity, AddDto, UpdateDto, EntityDto>.set => set;
}