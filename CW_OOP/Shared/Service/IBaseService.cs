public interface IBaseService<Key,
AddServiceDto,
UpdateServiceDto,
EntityServiceDto> :
IServiceAdd<AddServiceDto>,
IServiceDelete<Key>,
IServiceGetAll<EntityServiceDto>,
IServiceGetById<Key, EntityServiceDto>,
IServiceUpdate<UpdateServiceDto>
where Key : IComparable<Key>
{

}
public interface IBaseService<Key,
AddServiceDto,
EntityServiceDto,
UpdateServiceDto,
AddRepositoryDto,
EntityRepositoryDto,
UpdateRepositoryDto>:
IBaseService<Key,
AddServiceDto,
UpdateServiceDto,
EntityServiceDto>,
IServiceAdd<AddServiceDto, AddRepositoryDto>,
IServiceDelete<Key>,
IServiceGetAll<EntityServiceDto, EntityRepositoryDto>,
IServiceGetById<Key, EntityServiceDto, EntityRepositoryDto>,
IServiceUpdate<UpdateServiceDto, UpdateRepositoryDto>
where Key : IComparable<Key>
where AddServiceDto : IConvertible<AddRepositoryDto>
where EntityRepositoryDto : IConvertible<EntityServiceDto>
where UpdateServiceDto : IConvertible<UpdateRepositoryDto>
{
    protected IBaseRepository<Key, AddRepositoryDto, UpdateRepositoryDto, EntityRepositoryDto> repository { get; }

    IRepositoryAdd<AddRepositoryDto> IServiceAdd<AddServiceDto, AddRepositoryDto>.repository => repository;

    IRepositoryDelete<Key> IServiceDelete<Key>.repository => repository;

    IRepositoryGetAll<EntityRepositoryDto> IServiceGetAll<EntityServiceDto, EntityRepositoryDto>.repository => repository;

    IRepositoryUpdate<UpdateRepositoryDto> IServiceUpdate<UpdateServiceDto, UpdateRepositoryDto>.repository => repository;

    IRepositoryGetById<Key, EntityRepositoryDto> IServiceGetById<Key, EntityServiceDto, EntityRepositoryDto>.repository => repository;
}

public abstract class BaseService<Key,
AddServiceDto,
EntityServiceDto,
UpdateServiceDto,
AddRepositoryDto,
EntityRepositoryDto,
UpdateRepositoryDto> : IBaseService<Key,
AddServiceDto,
EntityServiceDto,
UpdateServiceDto,
AddRepositoryDto,
EntityRepositoryDto,
UpdateRepositoryDto>
where Key : IComparable<Key>
where AddServiceDto : IConvertible<AddRepositoryDto>
where EntityRepositoryDto : IConvertible<EntityServiceDto>
where UpdateServiceDto : IConvertible<UpdateRepositoryDto>
{
    private IBaseRepository<Key, AddRepositoryDto, UpdateRepositoryDto, EntityRepositoryDto> repository;
    public BaseService(IBaseRepository<Key, AddRepositoryDto, UpdateRepositoryDto, EntityRepositoryDto> repository)
    {
        this.repository = repository;
    }
    IBaseRepository<Key, AddRepositoryDto, UpdateRepositoryDto, EntityRepositoryDto> IBaseService<Key, AddServiceDto, EntityServiceDto, UpdateServiceDto, AddRepositoryDto, EntityRepositoryDto, UpdateRepositoryDto>.repository => repository;
}