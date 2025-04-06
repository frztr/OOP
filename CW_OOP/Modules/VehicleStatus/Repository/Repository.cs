
using Global;
using Microsoft.EntityFrameworkCore;
using VehicleStatus.DTO;
namespace VehicleStatus;
public class Repository(AppDbContext db) : IRepository
{
    DbSet<Global.VehicleStatus> set = db.Set<Global.VehicleStatus>();
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

    public EntityListDto GetAll()
    {
        return new EntityListDto()
        {
            items = set.Select(x => new EntityDto(x))
        };
    }

    public EntityDto GetById(short id)
    {
        return new EntityDto(set.FirstOrDefault(x => x.Id == id));
    }

    public EntityListDto GetByIds(short[] ids)
    {
        return new EntityListDto()
        {
            items = set.Where(x => ids.Contains(x.Id)).Select(x => new EntityDto(x))
        };
    }

    public void Update(UpdateDto updateDto)
    {
        var entity = set.FirstOrDefault(x => x.Id == updateDto.Id);
        updateDto.Update(entity);
        db.SaveChanges();
    }
}