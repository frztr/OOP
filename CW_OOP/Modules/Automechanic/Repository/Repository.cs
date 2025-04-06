
using Global;
using Microsoft.EntityFrameworkCore;
using Automechanic.DTO;
namespace Automechanic;
public class Repository(AppDbContext db) : IRepository
{
    DbSet<Global.Automechanic> set = db.Set<Global.Automechanic>();
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

    public EntityListDto GetAll()
    {
        return new EntityListDto()
        {
            items = set.Include(x => x.User).Select(x => new EntityDto(x))
        };
    }

    public EntityDto GetById(short id)
    {
        return new EntityDto(set.Include(x => x.User).FirstOrDefault(x => x.Id == id));
    }

    public void Update(UpdateDto updateDto)
    {
        var entity = set.FirstOrDefault(x => x.Id == updateDto.Id);
        updateDto.Update(entity);
        db.SaveChanges();
    }
}