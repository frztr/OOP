using Driver.DTO;
using Global;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public interface IIBaseRepository<Key, AddDto, UpdateDto, EntityDto, EntityListDto> :
IIRepositoryAdd<AddDto>,
IIRepositoryDelete<Key>,
IIRepositoryGetAll<EntityListDto, EntityDto>,
IIRepositoryGetById<Key, EntityDto>,
IIRepositoryUpdate<UpdateDto>
where Key : IComparable<Key>
where EntityListDto : IListDto<EntityDto>
{

}
public interface IBaseRepository<Key, Entity, AddDto, UpdateDto, EntityDto, EntityListDto> :
IIBaseRepository<Key, AddDto, UpdateDto, EntityDto, EntityListDto>,
IRepositoryAdd<AddDto, Entity>,
IRepositoryDelete<Key, Entity>,
IRepositoryGetAll<EntityListDto,EntityDto, Entity>,
IRepositoryGetById<Key, EntityDto, Entity>,
IRepositoryUpdate<UpdateDto, Entity, Key>
where Key : IComparable<Key>
where Entity : class, IEntity<Key>, IConvertible<EntityDto>
where AddDto : IConvertible<Entity>
where UpdateDto : IUpdateDto<Key, Entity>
where EntityListDto : IListDto<EntityDto>
{
    protected AppDbContext db { get; }

    protected DbSet<Entity> set { get; }

    AppDbContext IRepositoryAdd<AddDto, Entity>.db => db;

    AppDbContext IRepositoryDelete<Key, Entity>.db => db;

    AppDbContext IRepositoryUpdate<UpdateDto, Entity, Key>.db => db;

    DbSet<Entity> IRepositoryAdd<AddDto, Entity>.set => set;

    DbSet<Entity> IRepositoryDelete<Key, Entity>.set => set;

    DbSet<Entity> IRepositoryGetAll<EntityListDto, EntityDto, Entity>.set=> set;

    DbSet<Entity> IRepositoryGetById<Key, EntityDto, Entity>.set => set;

    DbSet<Entity> IRepositoryUpdate<UpdateDto, Entity, Key>.set => set;
}

public abstract class BaseRepository<Key, Entity, AddDto, UpdateDto, EntityDto, EntityListDto> :
IBaseRepository<Key, Entity, AddDto, UpdateDto, EntityDto, EntityListDto>
where Key : IComparable<Key>
where Entity : class, IEntity<Key>, IConvertible<EntityDto>
where AddDto : IConvertible<Entity>
where UpdateDto : IUpdateDto<Key, Entity>
where EntityListDto : IListDto<EntityDto>
{
    protected AppDbContext db;
    protected DbSet<Entity> set;

    protected IConverter<IEnumerable<EntityDto>, EntityListDto<EntityDto>> converter;
    public BaseRepository(AppDbContext db, IConverter<IEnumerable<EntityDto>, EntityListDto<EntityDto>> converter)
    {
        this.db = db;
        this.set = db.Set<Entity>();
        this.converter = converter;
    }
    AppDbContext IBaseRepository<Key, Entity, AddDto, UpdateDto, EntityDto, EntityListDto>.db => db;

    DbSet<Entity> IBaseRepository<Key, Entity, AddDto, UpdateDto, EntityDto, EntityListDto>.set => set;

    IConverter<IEnumerable<EntityDto>, EntityListDto<EntityDto>> IRepositoryGetAll<EntityListDto, EntityDto, Entity>.converter => converter;
}