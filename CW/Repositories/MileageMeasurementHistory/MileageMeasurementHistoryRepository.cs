
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class MileageMeasurementHistoryRepository(AppDbContext db) : IMileageMeasurementHistoryRepository
{ 
    DbSet<MileageMeasurementHistory> set = db.Set<MileageMeasurementHistory>();
    public async Task<MileageMeasurementHistoryRepositoryDto> AddAsync(AddMileageMeasurementHistoryRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddMileageMeasurementHistoryRepositoryDto, MileageMeasurementHistory>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddMileageMeasurementHistoryRepositoryDto, MileageMeasurementHistory>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<MileageMeasurementHistory,MileageMeasurementHistoryRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<MileageMeasurementHistory,MileageMeasurementHistoryRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(int id)
    {
        set.Remove(await set.FirstOrDefaultAsync(x => x.Id == id));
        await db.SaveChangesAsync();
    }

    public async Task<MileageMeasurementHistoryListRepositoryDto> GetAllAsync(MileageMeasurementHistoryQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<MileageMeasurementHistory,MileageMeasurementHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        return new MileageMeasurementHistoryListRepositoryDto()
        {
            Items = mapper.Map<List<MileageMeasurementHistoryRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<MileageMeasurementHistoryRepositoryDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<MileageMeasurementHistory,MileageMeasurementHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        return mapper.Map<MileageMeasurementHistory,MileageMeasurementHistoryRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateMileageMeasurementHistoryRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateMileageMeasurementHistoryRepositoryDto, MileageMeasurementHistory>());
        var mapper = new Mapper(config);
        mapper.Map<UpdateMileageMeasurementHistoryRepositoryDto, MileageMeasurementHistory>(updateDto,entity);
        db.SaveChangesAsync();
    }
}