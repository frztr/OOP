
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
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<FuelMeasurementHistory>(new {id});
        set.Remove(entity);
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
			.Where(x=> queryDto.Id_GT.HasValue ? x.Id > queryDto.Id_GT.Value : true)
            .Where(x=> queryDto.Id_GTE.HasValue ? x.Id >= queryDto.Id_GTE.Value : true)
            .Where(x=> queryDto.Id_LT.HasValue ? x.Id < queryDto.Id_LT.Value : true)
            .Where(x=> queryDto.Id_LTE.HasValue ? x.Id <= queryDto.Id_LTE.Value : true)
            .Where(x=> queryDto.Id_EQ.HasValue ? x.Id == queryDto.Id_EQ.Value : true)
			.Where(x=> queryDto.Volume_GT.HasValue ? x.Volume > queryDto.Volume_GT.Value : true)
            .Where(x=> queryDto.Volume_GTE.HasValue ? x.Volume >= queryDto.Volume_GTE.Value : true)
            .Where(x=> queryDto.Volume_LT.HasValue ? x.Volume < queryDto.Volume_LT.Value : true)
            .Where(x=> queryDto.Volume_LTE.HasValue ? x.Volume <= queryDto.Volume_LTE.Value : true)
            .Where(x=> queryDto.Volume_EQ.HasValue ? x.Volume == queryDto.Volume_EQ.Value : true)
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

    public async Task<FuelMeasurementHistoryRepositoryDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<FuelMeasurementHistory,FuelMeasurementHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<FuelMeasurementHistory>(new {id});
        return mapper.Map<FuelMeasurementHistory,FuelMeasurementHistoryRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateFuelMeasurementHistoryRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<FuelMeasurementHistory>(new {Id = updateDto.Id});
		if(updateDto.Volume.HasValue){
            entity.Volume = updateDto.Volume.Value;
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