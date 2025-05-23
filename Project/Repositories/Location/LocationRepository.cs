
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class LocationRepository(AppDbContext db) : ILocationRepository
{ 
    DbSet<Location> set = db.Set<Location>();
    public async Task<LocationRepositoryDto> AddAsync(AddLocationRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddLocationRepositoryDto, Location>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddLocationRepositoryDto, Location>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<Location,LocationRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<Location,LocationRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(short id)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<Location>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<LocationListRepositoryDto> GetAllAsync(LocationQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Location,LocationRepositoryDto>());
        var mapper = new Mapper(config);
        return new LocationListRepositoryDto()
        {
            Items = mapper.Map<List<LocationRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<LocationRepositoryDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Location,LocationRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<Location>(new {id});
        return mapper.Map<Location,LocationRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateLocationRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<Location>(new {Id = updateDto.Id});
		if(!String.IsNullOrEmpty(updateDto.Name)){
            entity.Name = updateDto.Name;
        }
		if(!String.IsNullOrEmpty(updateDto.Address)){
            entity.Address = updateDto.Address;
        }


        await db.SaveChangesAsync();
    }
}