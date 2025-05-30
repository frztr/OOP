
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class CityRepository(AppDbContext db) : ICityRepository
{ 
    DbSet<City> set = db.Set<City>();
    public async Task<CityRepositoryDto> AddAsync(AddCityRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddCityRepositoryDto, City>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddCityRepositoryDto, City>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<City,CityRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<City,CityRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<City>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<CityListRepositoryDto> GetAllAsync(CityQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<City,CityRepositoryDto>());
        var mapper = new Mapper(config);
        return new CityListRepositoryDto()
        {
            Items = mapper.Map<List<CityRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<CityRepositoryDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<City,CityRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<City>(new {id});
        return mapper.Map<City,CityRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateCityRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<City>(new {Id = updateDto.Id});
		if(!String.IsNullOrEmpty(updateDto.Name)){
            entity.Name = updateDto.Name;
        }
		if(updateDto.CountryId.HasValue){
            entity.CountryId = updateDto.CountryId.Value;
        }


        await db.SaveChangesAsync();
    }
}