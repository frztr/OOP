
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class CountryRepository(AppDbContext db) : ICountryRepository
{ 
    DbSet<Country> set = db.Set<Country>();
    public async Task<CountryRepositoryDto> AddAsync(AddCountryRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddCountryRepositoryDto, Country>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddCountryRepositoryDto, Country>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<Country,CountryRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<Country,CountryRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(short id)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<Country>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<CountryListRepositoryDto> GetAllAsync(CountryQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Country,CountryRepositoryDto>());
        var mapper = new Mapper(config);
        return new CountryListRepositoryDto()
        {
            Items = mapper.Map<List<CountryRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<CountryRepositoryDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Country,CountryRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<Country>(new {id});
        return mapper.Map<Country,CountryRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateCountryRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<Country>(new {Id = updateDto.Id});
		if(!String.IsNullOrEmpty(updateDto.Name)){
            entity.Name = updateDto.Name;
        }

        await db.SaveChangesAsync();
    }
}