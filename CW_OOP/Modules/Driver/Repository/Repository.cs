
using Global;
using Microsoft.EntityFrameworkCore;
using Driver.DTO;
namespace Driver;
public class Repository(AppDbContext db) : IRepository
{
    DbSet<Global.Driver> set = db.Set<Global.Driver>();
    public EntityDto Add(AddRepositoryDto addDto)
    {
        var entity = addDto.Convert();
        set.Add(entity);
        db.SaveChanges();
        return new EntityDto(entity);
    }

    public void Delete(short id)
    {
        set.ToList().Remove(set.FirstOrDefault(x => x.Id == id));
        db.SaveChanges();
    }

    public EntityRepositoryListDto GetAll()
    {
        return new EntityRepositoryListDto()
        {
            items = set.Select(x => new EntityDto(x))
        };
    }

    public EntityDto GetById(short id)
    {
        return new EntityDto(set.FirstOrDefault(x => x.Id == id));
    }

    public void Update(UpdateDto updateDto)
    {
        var entity = set.FirstOrDefault(x => x.Id == updateDto.Id);
        updateDto.Update(entity);
        db.SaveChanges();
    }
}