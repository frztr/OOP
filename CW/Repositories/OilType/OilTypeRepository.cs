
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class OilTypeRepository(AppDbContext db) : IOilTypeRepository
{ 
    DbSet<OilType> set = db.Set<OilType>();
    public async Task<OilTypeRepositoryDto> AddAsync(AddOilTypeRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddOilTypeRepositoryDto, OilType>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddOilTypeRepositoryDto, OilType>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<OilType,OilTypeRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<OilType,OilTypeRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(short id)
    {
        set.Remove(await set.FirstOrDefaultAsync(x => x.Id == id));
        await db.SaveChangesAsync();
    }

    public async Task<OilTypeListRepositoryDto> GetAllAsync(OilTypeQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<OilType,OilTypeRepositoryDto>());
        var mapper = new Mapper(config);
        return new OilTypeListRepositoryDto()
        {
            Items = mapper.Map<List<OilTypeRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<OilTypeRepositoryDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<OilType,OilTypeRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        return mapper.Map<OilType,OilTypeRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateOilTypeRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
		if(!String.IsNullOrEmpty(updateDto.Name)){
            entity.Name = updateDto.Name;
        }
		if(updateDto.FuelTypeId.HasValue){
            entity.FuelTypeId = updateDto.FuelTypeId.Value;
        }

        await db.SaveChangesAsync();
    }
}