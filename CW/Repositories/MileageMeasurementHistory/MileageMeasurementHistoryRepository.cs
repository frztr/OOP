
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
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<MileageMeasurementHistory>(new {id});
        set.Remove(entity);
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
			.Where(x=> queryDto.Id_GT.HasValue ? x.Id > queryDto.Id_GT.Value : true)
            .Where(x=> queryDto.Id_GTE.HasValue ? x.Id >= queryDto.Id_GTE.Value : true)
            .Where(x=> queryDto.Id_LT.HasValue ? x.Id < queryDto.Id_LT.Value : true)
            .Where(x=> queryDto.Id_LTE.HasValue ? x.Id <= queryDto.Id_LTE.Value : true)
            .Where(x=> queryDto.Id_EQ.HasValue ? x.Id == queryDto.Id_EQ.Value : true)
			.Where(x=> queryDto.KmCount_GT.HasValue ? x.KmCount > queryDto.KmCount_GT.Value : true)
            .Where(x=> queryDto.KmCount_GTE.HasValue ? x.KmCount >= queryDto.KmCount_GTE.Value : true)
            .Where(x=> queryDto.KmCount_LT.HasValue ? x.KmCount < queryDto.KmCount_LT.Value : true)
            .Where(x=> queryDto.KmCount_LTE.HasValue ? x.KmCount <= queryDto.KmCount_LTE.Value : true)
            .Where(x=> queryDto.KmCount_EQ.HasValue ? x.KmCount == queryDto.KmCount_EQ.Value : true)
			.Where(x=> queryDto.MeasurementDate_GT.HasValue ? x.MeasurementDate > queryDto.MeasurementDate_GT.Value : true)
            .Where(x=> queryDto.MeasurementDate_GTE.HasValue ? x.MeasurementDate >= queryDto.MeasurementDate_GTE.Value : true)
            .Where(x=> queryDto.MeasurementDate_LT.HasValue ? x.MeasurementDate < queryDto.MeasurementDate_LT.Value : true)
            .Where(x=> queryDto.MeasurementDate_LTE.HasValue ? x.MeasurementDate <= queryDto.MeasurementDate_LTE.Value : true)
            .Where(x=> queryDto.MeasurementDate_EQ.HasValue ? x.MeasurementDate == queryDto.MeasurementDate_EQ.Value : true)
			.Where(x=> queryDto.VehicleId_GT.HasValue ? x.VehicleId > queryDto.VehicleId_GT.Value : true)
            .Where(x=> queryDto.VehicleId_GTE.HasValue ? x.VehicleId >= queryDto.VehicleId_GTE.Value : true)
            .Where(x=> queryDto.VehicleId_LT.HasValue ? x.VehicleId < queryDto.VehicleId_LT.Value : true)
            .Where(x=> queryDto.VehicleId_LTE.HasValue ? x.VehicleId <= queryDto.VehicleId_LTE.Value : true)
            .Where(x=> queryDto.VehicleId_EQ.HasValue ? x.VehicleId == queryDto.VehicleId_EQ.Value : true)
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<MileageMeasurementHistoryRepositoryDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<MileageMeasurementHistory,MileageMeasurementHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<MileageMeasurementHistory>(new {id});
        return mapper.Map<MileageMeasurementHistory,MileageMeasurementHistoryRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateMileageMeasurementHistoryRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<MileageMeasurementHistory>(new {Id = updateDto.Id});
		if(updateDto.KmCount.HasValue){
            entity.KmCount = updateDto.KmCount.Value;
        }
		if(updateDto.MeasurementDate.HasValue){
            entity.MeasurementDate = updateDto.MeasurementDate.Value;
        }
		if(updateDto.VehicleId.HasValue){
            entity.VehicleId = updateDto.VehicleId.Value;
        }

        await db.SaveChangesAsync();
    }
}