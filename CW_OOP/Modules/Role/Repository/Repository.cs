
using Global;
using Microsoft.EntityFrameworkCore;
using Role.DTO;
namespace Role;
public class Repository(AppDbContext db) : IRepository
{
    IQueryable<Global.Role> set = db.Set<Global.Role>();
    public void Add(DTO.AddDto addDto)
    {
        set.ToList().Add(addDto.Convert());
        db.SaveChanges();
    }

    public void Delete(short id)
    {
        set.ToList().Remove(set.FirstOrDefault(x => x.Id == id));
        db.SaveChanges();
    }

    public IEnumerable<DTO.EntityDto> GetAll()
    {
        return set.Select(x => new EntityDto(x));
    }

    public DTO.EntityDto GetById(short id)
    {
        return new EntityDto(set.FirstOrDefault(x => x.Id == id));
    }

    public void Update(DTO.UpdateDto updateDto)
    {
        Global.Role entity = set.FirstOrDefault(x => x.Id == updateDto.Id);
        updateDto.Update(entity);
        db.SaveChanges();
    }
}