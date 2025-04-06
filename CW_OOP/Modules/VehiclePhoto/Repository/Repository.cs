
using Global;
using Microsoft.EntityFrameworkCore;
using VehiclePhoto.DTO;
namespace VehiclePhoto;
public class Repository(AppDbContext db) : IRepository
{
    DbSet<Global.VehiclePhoto> set = db.Set<Global.VehiclePhoto>();
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

    public EntityListDto GetByVehicleId(int id)
    {
        return new EntityListDto()
        {
            items = set.Where(x=>x.VehicleId == id).Select(x => new EntityDto(x))
        };
    }
}