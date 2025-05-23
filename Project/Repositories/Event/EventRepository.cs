
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class EventRepository(AppDbContext db) : IEventRepository
{ 
    DbSet<Event> set = db.Set<Event>();
    public async Task<EventRepositoryDto> AddAsync(AddEventRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddEventRepositoryDto, Event>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddEventRepositoryDto, Event>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<Event,EventRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<Event,EventRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<Event>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<EventListRepositoryDto> GetAllAsync(EventQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Event,EventRepositoryDto>());
        var mapper = new Mapper(config);
        return new EventListRepositoryDto()
        {
            Items = mapper.Map<List<EventRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<EventRepositoryDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Event,EventRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<Event>(new {id});
        return mapper.Map<Event,EventRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateEventRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<Event>(new {Id = updateDto.Id});
		if(!String.IsNullOrEmpty(updateDto.Title)){
            entity.Title = updateDto.Title;
        }
		if(!String.IsNullOrEmpty(updateDto.Description)){
            entity.Description = updateDto.Description;
        }
		if(updateDto.LocationId.HasValue){
            entity.LocationId = updateDto.LocationId.Value;
        }

		if(updateDto.StartTime.HasValue){
            entity.StartTime = updateDto.StartTime.Value;
        }
		if(updateDto.EndTime.HasValue){
            entity.EndTime = updateDto.EndTime.Value;
        }
		if(updateDto.CreatedBy.HasValue){
            entity.CreatedBy = updateDto.CreatedBy.Value;
        }

		if(updateDto.EventCategoryId.HasValue){
            entity.EventCategoryId = updateDto.EventCategoryId.Value;
        }



        await db.SaveChangesAsync();
    }
}