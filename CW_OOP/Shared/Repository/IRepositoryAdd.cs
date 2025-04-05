using Global;
using Microsoft.EntityFrameworkCore;

public interface IIRepositoryAdd<AddDto>{
    public void Add(AddDto addDto);
}

public interface IRepositoryAdd<AddDto, Entity> : IIRepositoryAdd<AddDto>
where Entity : class
where AddDto : IConvertible<Entity>
{
    protected AppDbContext db {get;}
    protected DbSet<Entity> set { get; }
    void IIRepositoryAdd<AddDto>.Add(AddDto addDto)
    {
        set.Add(addDto.Convert());
        db.SaveChanges();
    }
}