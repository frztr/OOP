using Global;
using Microsoft.EntityFrameworkCore;

public interface IRepositoryAdd<AddDto>{
    public void Add(AddDto addDto);
}

public interface IRepositoryAdd<AddDto, Entity> : IRepositoryAdd<AddDto>
where Entity : class
where AddDto : IConvertible<Entity>
{
    protected AppDbContext db {get;}
    protected DbSet<Entity> set { get; }
    void IRepositoryAdd<AddDto>.Add(AddDto addDto)
    {
        set.Add(addDto.Convert());
        db.SaveChanges();
    }
}