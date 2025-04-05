
using Global;
using Microsoft.EntityFrameworkCore;
using Driver.DTO;
namespace Driver;
public class Repository(AppDbContext db) : IRepository
{
    DbSet<Global.Driver> set = db.Set<Global.Driver>();
    public void Add(AddDto addDto)
    {
        set.Add(addDto.Convert());
        db.SaveChanges();
    }

    public void Delete(short id)
    {
        set.ToList().Remove(set.FirstOrDefault(x => x.Id == id));
        db.SaveChanges();
    }

    public IEnumerable<EntityDto> GetAll()
    {
        return set.Include(x=>x.User).Select(x => new EntityDto(x));
    }

    public EntityDto GetById(short id)
    {
        return new EntityDto(db.Drivers.Include(x=>x.User).FirstOrDefault(x => x.UserId == id));
    }

    public void Update(UpdateDto updateDto)
    {
        var entity = set.FirstOrDefault(x => x.Id == updateDto.Id);
        updateDto.Update(entity);
        db.SaveChanges();
    }
}