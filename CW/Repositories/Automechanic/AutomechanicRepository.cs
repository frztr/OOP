
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class AutomechanicRepository(AppDbContext db) : IAutomechanicRepository
{ 
    DbSet<Automechanic> set = db.Set<Automechanic>();
    public async Task<AutomechanicRepositoryDto> AddAsync(AddAutomechanicRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddAutomechanicRepositoryDto, Automechanic>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddAutomechanicRepositoryDto, Automechanic>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<Automechanic,AutomechanicRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<Automechanic,AutomechanicRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(short id)
    {
        set.Remove(await set.FirstOrDefaultAsync(x => x.UserId == id));
        await db.SaveChangesAsync();
    }

    public async Task<AutomechanicListRepositoryDto> GetAllAsync(short count = 50, short offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Automechanic,AutomechanicRepositoryDto>());
        var mapper = new Mapper(config);
        return new AutomechanicListRepositoryDto()
        {
            Items = mapper.Map<List<AutomechanicRepositoryDto>>(
            await set.Skip(offset).Take(count < 50 ? count : 50).ToListAsync()
            )
        };
    }

    public async Task<AutomechanicRepositoryDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Automechanic,AutomechanicRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.UserId == id);
        return mapper.Map<Automechanic,AutomechanicRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateAutomechanicRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.UserId == updateDto.UserId);
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateAutomechanicRepositoryDto, Automechanic>());
        var mapper = new Mapper(config);
        mapper.Map<UpdateAutomechanicRepositoryDto, Automechanic>(updateDto,entity);
        db.SaveChangesAsync();
    }
}