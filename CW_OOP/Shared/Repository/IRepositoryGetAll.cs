using Microsoft.EntityFrameworkCore;

public interface IRepositoryGetAll<EntityDto>{
    public IEnumerable<EntityDto> GetAll();
}

public interface IRepositoryGetAll<EntityDto, Entity> : IRepositoryGetAll<EntityDto>
where Entity : class, IConvertible<EntityDto>
{
    protected DbSet<Entity> set { get; }
    IEnumerable<EntityDto> IRepositoryGetAll<EntityDto>.GetAll()
    {   
        return set.Select(x => x.Convert());
        // return set.Select(x => (EntityDto)ActivatorUtilities.CreateInstance(typeof(EntityDto),x));
    }    
}