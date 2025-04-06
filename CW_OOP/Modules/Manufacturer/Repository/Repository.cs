
using Global;
using Microsoft.EntityFrameworkCore;
using Manufacturer.DTO;
namespace Manufacturer;
public class Repository(AppDbContext db) : IRepository
{
    DbSet<Global.Manufacturer> set = db.Set<Global.Manufacturer>();
    public EntityDto Add(AddDto addDto)
    {
        var entity = addDto.Convert();
        set.Add(addDto.Convert());
        db.SaveChanges();
        return new EntityDto(entity);
    }

    public void Delete(short id)
    {
        set.ToList().Remove(set.FirstOrDefault(x => x.Id == id));
        db.SaveChanges();
    }

    public EntityListDto GetAll(short count = 50, short offset = 0)
    {
        return new EntityListDto()
        {
            items = set.Skip(offset).Take(count < 50 ? count : 50).Select(x => new EntityDto(x))
        };
    }

    public EntityDto GetById(short id)
    {
        return new EntityDto(set.FirstOrDefault(x => x.Id == id));
    }

    public EntityListDto GetByIds(short[] ids, short count = 50, short offset = 0)
    {
        return new EntityListDto()
        {
            items = set.Where(x=>ids.Contains(x.Id)).Skip(offset).Take(count < 50 ? count : 50).Select(x => new EntityDto(x))
        };
    }

    public void Update(UpdateDto updateDto)
    {
        var entity = set.FirstOrDefault(x => x.Id == updateDto.Id);
        updateDto.Update(entity);
        db.SaveChanges();
    }
}