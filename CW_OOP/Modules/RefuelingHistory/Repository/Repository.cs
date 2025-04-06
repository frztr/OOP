
using Global;
using Microsoft.EntityFrameworkCore;
using RefuelingHistory.DTO;
namespace RefuelingHistory;
public class Repository(AppDbContext db) : IRepository
{
    DbSet<Global.RefuelingHistory> set = db.Set<Global.RefuelingHistory>();
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

    public EntityListDto GetAll(int count = 50, int offset = 0)
    {
        return new EntityListDto()
        {
            Items = set.Skip(offset).Take(count < 50 ? count : count).Select(x => new EntityDto(x))
        };
    }

    public EntityListDto GetByVehicleId(int vehicleId,int count = 50, int offset = 0)
    {
        return new EntityListDto()
        {
            Items = set.Where(x=>x.VehicleId == vehicleId).Skip(offset).Take(count).Select(x => new EntityDto(x))
        };
    }

    public EntityListDto GetByDriverId(int driverId,int count = 50, int offset = 0)
    {
        return new EntityListDto()
        {
            Items = set.Where(x=>x.DriverId == driverId).Skip(offset).Take(count).Select(x => new EntityDto(x))
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