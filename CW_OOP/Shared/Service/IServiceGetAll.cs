public interface IServiceGetAll<EntityServiceDto>
{
    public abstract IEnumerable<EntityServiceDto> GetAll();
}
public interface IServiceGetAll<EntityServiceDto, EntityRepositoryDto> 
: IServiceGetAll<EntityServiceDto>
where EntityRepositoryDto: IConvertible<EntityServiceDto>
{
    protected IRepositoryGetAll<EntityRepositoryDto> repository { get; }
    IEnumerable<EntityServiceDto> IServiceGetAll<EntityServiceDto>.GetAll()
    {
        return repository.GetAll().Select(x=>x.Convert());
    }
}