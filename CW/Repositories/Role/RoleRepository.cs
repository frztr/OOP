
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class RoleRepository(AppDbContext db) : IRoleRepository
{ 
    DbSet<Role> set = db.Set<Role>();
    public async Task<RoleRepositoryDto> AddAsync(AddRoleRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddRoleRepositoryDto, Role>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddRoleRepositoryDto, Role>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<Role,RoleRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<Role,RoleRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(short id)
    {
        set.Remove(await set.FirstOrDefaultAsync(x => x.Id == id));
        await db.SaveChangesAsync();
    }

    public async Task<RoleListRepositoryDto> GetAllAsync(short count = 50, short offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Role,RoleRepositoryDto>());
        var mapper = new Mapper(config);
        return new RoleListRepositoryDto()
        {
            Items = mapper.Map<List<RoleRepositoryDto>>(
            await set.Skip(offset).Take(count < 50 ? count : 50).ToListAsync()
            )
        };
    }

    public async Task<RoleRepositoryDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Role,RoleRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        return mapper.Map<Role,RoleRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateRoleRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateRoleRepositoryDto, Role>());
        var mapper = new Mapper(config);
        mapper.Map<UpdateRoleRepositoryDto, Role>(updateDto,entity);
        db.SaveChangesAsync();
    }
}