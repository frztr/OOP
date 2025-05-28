
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
        var entity = await set.FirstOrDefaultAsync(x => x.UserId == id);
        if(entity == null) throw new EntityNotFoundException<Automechanic>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<AutomechanicListRepositoryDto> GetAllAsync(AutomechanicQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Automechanic,AutomechanicRepositoryDto>());
        var mapper = new Mapper(config);
        return new AutomechanicListRepositoryDto()
        {
            Items = mapper.Map<List<AutomechanicRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<AutomechanicRepositoryDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Automechanic,AutomechanicRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.UserId == id);
        if(entity == null) throw new EntityNotFoundException<Automechanic>(new {id});
        return mapper.Map<Automechanic,AutomechanicRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateAutomechanicRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.UserId == updateDto.UserId);
        if(entity == null) throw new EntityNotFoundException<Automechanic>(new {UserId = updateDto.UserId});

		if(!String.IsNullOrEmpty(updateDto.Qualification)){
            entity.Qualification = updateDto.Qualification;
        }


        await db.SaveChangesAsync();
    }
}