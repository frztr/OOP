
using Global;
using Microsoft.EntityFrameworkCore;
using Vehicle.DTO;
namespace Vehicle;
public class Repository(AppDbContext db) : IRepository
{
    DbSet<Global.Vehicle> set = db.Set<Global.Vehicle>();
    public EntityDto Add(AddDto addDto)
    {
        var entity = addDto.Convert();
        set.Add(addDto.Convert());
        db.SaveChanges();
        return new EntityDto(entity);
    }

    public void Delete(int id)
    {
        set.ToList().Remove(set.FirstOrDefault(x => x.Id == id));
        db.SaveChanges();
    }

    public EntityListDto GetAll(int count = 50, int offset = 0)
    {
        return new EntityListDto()
        {
            items = set.Skip(offset).Take(count < 50 ? count : 50).Select(x => new EntityDto(x))
        };
    }

    public EntityDto GetById(int id)
    {
        return new EntityDto(set.FirstOrDefault(x => x.Id == id));
    }

    public EntityListDto GetByIds(int[] ids, int count = 50, int offset = 0)
    {
        return new EntityListDto()
        {
            items = set.Where(x => ids.Contains(x.Id)).Skip(offset).Take(count < 50 ? count : 50).Select(x => new EntityDto(x))
        };
    }

    public void Update(UpdateDto updateDto)
    {
        var entity = set.FirstOrDefault(x => x.Id == updateDto.Id);
        updateDto.Update(entity);
        db.SaveChanges();
    }
}