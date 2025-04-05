
using Global;
using Microsoft.EntityFrameworkCore;
using Role.DTO;
namespace Role;
// public class Repository(AppDbContext db) : IRepository
// {
//     DbSet<Global.Role> set = db.Set<Global.Role>();
//     public void Add(AddDto addDto)
//     {
//         set.Add(addDto.Convert());
//         db.SaveChanges();
//     }

//     public void Delete(short id)
//     {
//         set.ToList().Remove(set.FirstOrDefault(x => x.Id == id));
//         db.SaveChanges();
//     }

//     public IEnumerable<EntityDto> GetAll()
//     {
//         return set.Select(x => new EntityDto(x));
//     }

//     public EntityDto GetById(short id)
//     {
//         return new EntityDto(set.FirstOrDefault(x => x.Id == id));
//     }

//     public void Update(DTO.UpdateDto updateDto)
//     {
//         var entity = set.FirstOrDefault(x => x.Id == updateDto.Id);
//         updateDto.Update(entity);
//         db.SaveChanges();
//     }
// }

public class Repository : BaseRepository<short, Global.Role, AddDto, UpdateDto, EntityDto>, IRepository
{
    public Repository(AppDbContext db) : base(db)
    {
    }
}