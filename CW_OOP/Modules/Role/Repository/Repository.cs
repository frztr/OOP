
using Global;
using Microsoft.EntityFrameworkCore;
using Role.DTO;
namespace Role;
public class Repository : BaseRepository<short, Global.Role, AddDto, UpdateDto, EntityRepositoryDto>, IRepository
{
    public Repository(AppDbContext db) : base(db)
    {
    }

    public int GetCount()
    {
        return this.db.Set<Global.Role>().Count();
    }
}