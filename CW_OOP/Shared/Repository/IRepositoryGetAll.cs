using Microsoft.EntityFrameworkCore;

public interface IIRepositoryGetAll<EntityListDto, EntityDto>
where EntityListDto : IListDto<EntityDto>
{
    public EntityListDto<EntityDto> GetAll();
}

public interface IRepositoryGetAll<EntityListDto, EntityDto, Entity> : IIRepositoryGetAll<EntityListDto, EntityDto>
where Entity : class, IConvertible<EntityDto>
where EntityListDto : IListDto<EntityDto>
{
    protected DbSet<Entity> set { get; }

    protected IConverter<IEnumerable<EntityDto>, EntityListDto<EntityDto>> converter { get; }
    EntityListDto<EntityDto> IIRepositoryGetAll<EntityListDto, EntityDto>.GetAll()
    {
        return converter.Convert(set.Select(x => x.Convert()));
        // return set.Select(x => (EntityDto)ActivatorUtilities.CreateInstance(typeof(EntityDto),x));
    }
}