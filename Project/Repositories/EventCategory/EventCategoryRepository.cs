
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class EventCategoryRepository(AppDbContext db) : IEventCategoryRepository
{ 
    DbSet<EventCategory> set = db.Set<EventCategory>();
    public async Task<EventCategoryRepositoryDto> AddAsync(AddEventCategoryRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddEventCategoryRepositoryDto, EventCategory>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddEventCategoryRepositoryDto, EventCategory>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<EventCategory,EventCategoryRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<EventCategory,EventCategoryRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(short id)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<EventCategory>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<EventCategoryListRepositoryDto> GetAllAsync(EventCategoryQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<EventCategory,EventCategoryRepositoryDto>());
        var mapper = new Mapper(config);
        return new EventCategoryListRepositoryDto()
        {
            Items = mapper.Map<List<EventCategoryRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<EventCategoryRepositoryDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<EventCategory,EventCategoryRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<EventCategory>(new {id});
        return mapper.Map<EventCategory,EventCategoryRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateEventCategoryRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<EventCategory>(new {Id = updateDto.Id});
		if(!String.IsNullOrEmpty(updateDto.Name)){
            entity.Name = updateDto.Name;
        }

        await db.SaveChangesAsync();
    }
}