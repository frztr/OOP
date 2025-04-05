
using Global;
using Microsoft.EntityFrameworkCore;
using Role.DTO;
namespace Role;
public class Repository : BaseRepository<short, Global.Role, AddDto, UpdateDto, EntityDto>, IRepository
{
    public Repository(AppDbContext db) : base(db)
    {
    }
}