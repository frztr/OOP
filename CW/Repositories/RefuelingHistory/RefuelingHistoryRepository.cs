
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class RefuelingHistoryRepository(AppDbContext db) : IRefuelingHistoryRepository
{ 
    DbSet<RefuelingHistory> set = db.Set<RefuelingHistory>();
    public async Task<RefuelingHistoryRepositoryDto> AddAsync(AddRefuelingHistoryRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddRefuelingHistoryRepositoryDto, RefuelingHistory>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddRefuelingHistoryRepositoryDto, RefuelingHistory>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<RefuelingHistory,RefuelingHistoryRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<RefuelingHistory,RefuelingHistoryRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<RefuelingHistory>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<RefuelingHistoryListRepositoryDto> GetAllAsync(RefuelingHistoryQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<RefuelingHistory,RefuelingHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        return new RefuelingHistoryListRepositoryDto()
        {
            Items = mapper.Map<List<RefuelingHistoryRepositoryDto>>(
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
			.Where(x=> queryDto.OilTypeId_GT.HasValue ? x.OilTypeId > queryDto.OilTypeId_GT.Value : true)
            .Where(x=> queryDto.OilTypeId_GTE.HasValue ? x.OilTypeId >= queryDto.OilTypeId_GTE.Value : true)
            .Where(x=> queryDto.OilTypeId_LT.HasValue ? x.OilTypeId < queryDto.OilTypeId_LT.Value : true)
            .Where(x=> queryDto.OilTypeId_LTE.HasValue ? x.OilTypeId <= queryDto.OilTypeId_LTE.Value : true)
            .Where(x=> queryDto.OilTypeId_EQ.HasValue ? x.OilTypeId == queryDto.OilTypeId_EQ.Value : true)

			.Where(x=> queryDto.FuelstationTinNumber_GT.HasValue ? x.FuelstationTinNumber > queryDto.FuelstationTinNumber_GT.Value : true)
            .Where(x=> queryDto.FuelstationTinNumber_GTE.HasValue ? x.FuelstationTinNumber >= queryDto.FuelstationTinNumber_GTE.Value : true)
            .Where(x=> queryDto.FuelstationTinNumber_LT.HasValue ? x.FuelstationTinNumber < queryDto.FuelstationTinNumber_LT.Value : true)
            .Where(x=> queryDto.FuelstationTinNumber_LTE.HasValue ? x.FuelstationTinNumber <= queryDto.FuelstationTinNumber_LTE.Value : true)
            .Where(x=> queryDto.FuelstationTinNumber_EQ.HasValue ? x.FuelstationTinNumber == queryDto.FuelstationTinNumber_EQ.Value : true)
			.Where(x=> queryDto.VehicleId_GT.HasValue ? x.VehicleId > queryDto.VehicleId_GT.Value : true)
            .Where(x=> queryDto.VehicleId_GTE.HasValue ? x.VehicleId >= queryDto.VehicleId_GTE.Value : true)
            .Where(x=> queryDto.VehicleId_LT.HasValue ? x.VehicleId < queryDto.VehicleId_LT.Value : true)
            .Where(x=> queryDto.VehicleId_LTE.HasValue ? x.VehicleId <= queryDto.VehicleId_LTE.Value : true)
            .Where(x=> queryDto.VehicleId_EQ.HasValue ? x.VehicleId == queryDto.VehicleId_EQ.Value : true)

			.Where(x=> queryDto.Price_GT.HasValue ? x.Price > queryDto.Price_GT.Value : true)
            .Where(x=> queryDto.Price_GTE.HasValue ? x.Price >= queryDto.Price_GTE.Value : true)
            .Where(x=> queryDto.Price_LT.HasValue ? x.Price < queryDto.Price_LT.Value : true)
            .Where(x=> queryDto.Price_LTE.HasValue ? x.Price <= queryDto.Price_LTE.Value : true)
            .Where(x=> queryDto.Price_EQ.HasValue ? x.Price == queryDto.Price_EQ.Value : true)
			.Where(x=> queryDto.Datetime_GT.HasValue ? x.Datetime > queryDto.Datetime_GT.Value : true)
            .Where(x=> queryDto.Datetime_GTE.HasValue ? x.Datetime >= queryDto.Datetime_GTE.Value : true)
            .Where(x=> queryDto.Datetime_LT.HasValue ? x.Datetime < queryDto.Datetime_LT.Value : true)
            .Where(x=> queryDto.Datetime_LTE.HasValue ? x.Datetime <= queryDto.Datetime_LTE.Value : true)
            .Where(x=> queryDto.Datetime_EQ.HasValue ? x.Datetime == queryDto.Datetime_EQ.Value : true)
			.Where(x=> queryDto.DriverId_GT.HasValue ? x.DriverId > queryDto.DriverId_GT.Value : true)
            .Where(x=> queryDto.DriverId_GTE.HasValue ? x.DriverId >= queryDto.DriverId_GTE.Value : true)
            .Where(x=> queryDto.DriverId_LT.HasValue ? x.DriverId < queryDto.DriverId_LT.Value : true)
            .Where(x=> queryDto.DriverId_LTE.HasValue ? x.DriverId <= queryDto.DriverId_LTE.Value : true)
            .Where(x=> queryDto.DriverId_EQ.HasValue ? x.DriverId == queryDto.DriverId_EQ.Value : true)
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<RefuelingHistoryRepositoryDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<RefuelingHistory,RefuelingHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<RefuelingHistory>(new {id});
        return mapper.Map<RefuelingHistory,RefuelingHistoryRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateRefuelingHistoryRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<RefuelingHistory>(new {Id = updateDto.Id});
		if(updateDto.Volume.HasValue){
            entity.Volume = updateDto.Volume.Value;
        }
		if(updateDto.OilTypeId.HasValue){
            entity.OilTypeId = updateDto.OilTypeId.Value;
        }

		if(updateDto.FuelstationTinNumber.HasValue){
            entity.FuelstationTinNumber = updateDto.FuelstationTinNumber.Value;
        }
		if(updateDto.VehicleId.HasValue){
            entity.VehicleId = updateDto.VehicleId.Value;
        }

		if(updateDto.Price.HasValue){
            entity.Price = updateDto.Price.Value;
        }
		if(updateDto.Datetime.HasValue){
            entity.Datetime = updateDto.Datetime.Value;
        }
		if(updateDto.DriverId.HasValue){
            entity.DriverId = updateDto.DriverId.Value;
        }

        await db.SaveChangesAsync();
    }
}