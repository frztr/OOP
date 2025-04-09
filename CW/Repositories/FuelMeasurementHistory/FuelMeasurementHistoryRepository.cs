
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class FuelMeasurementHistoryRepository(AppDbContext db) : IFuelMeasurementHistoryRepository
{ 
    DbSet<FuelMeasurementHistory> set = db.Set<FuelMeasurementHistory>();
    public async Task<FuelMeasurementHistoryRepositoryDto> AddAsync(AddFuelMeasurementHistoryRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddFuelMeasurementHistoryRepositoryDto, FuelMeasurementHistory>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddFuelMeasurementHistoryRepositoryDto, FuelMeasurementHistory>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<FuelMeasurementHistory,FuelMeasurementHistoryRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<FuelMeasurementHistory,FuelMeasurementHistoryRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(int id)
    {
        set.Remove(await set.FirstOrDefaultAsync(x => x.Id == id));
        await db.SaveChangesAsync();
    }

    public async Task<FuelMeasurementHistoryListRepositoryDto> GetAllAsync(FuelMeasurementHistoryQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<FuelMeasurementHistory,FuelMeasurementHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        return new FuelMeasurementHistoryListRepositoryDto()
        {
            Items = mapper.Map<List<FuelMeasurementHistoryRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<FuelMeasurementHistoryRepositoryDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<FuelMeasurementHistory,FuelMeasurementHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        return mapper.Map<FuelMeasurementHistory,FuelMeasurementHistoryRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateFuelMeasurementHistoryRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateFuelMeasurementHistoryRepositoryDto, FuelMeasurementHistory>());
        var mapper = new Mapper(config);
        mapper.Map<UpdateFuelMeasurementHistoryRepositoryDto, FuelMeasurementHistory>(updateDto,entity);
        db.SaveChangesAsync();
    }
}