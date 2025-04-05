
public interface IServiceGetById<Key,EntityServiceDto>
where Key : IComparable<Key>{
    public abstract EntityServiceDto GetById(Key id);
}
public interface IServiceGetById<Key,EntityServiceDto,EntityRepositoryDto> : IServiceGetById<Key,EntityServiceDto>
where EntityRepositoryDto : IConvertible<EntityServiceDto>
where Key : IComparable<Key>
{
    protected IRepositoryGetById<Key,EntityRepositoryDto> repository {get;}
    EntityServiceDto IServiceGetById<Key,EntityServiceDto>.GetById(Key id)
    {
        return repository.GetById(id).Convert();
    }
}