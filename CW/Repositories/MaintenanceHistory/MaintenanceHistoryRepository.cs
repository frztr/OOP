
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class MaintenanceHistoryRepository(AppDbContext db) : IMaintenanceHistoryRepository
{ 
    DbSet<MaintenanceHistory> set = db.Set<MaintenanceHistory>();
    public async Task<MaintenanceHistoryRepositoryDto> AddAsync(AddMaintenanceHistoryRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddMaintenanceHistoryRepositoryDto, MaintenanceHistory>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddMaintenanceHistoryRepositoryDto, MaintenanceHistory>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<MaintenanceHistory,MaintenanceHistoryRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<MaintenanceHistory,MaintenanceHistoryRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<MaintenanceHistory>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<MaintenanceHistoryListRepositoryDto> GetAllAsync(MaintenanceHistoryQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<MaintenanceHistory,MaintenanceHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        return new MaintenanceHistoryListRepositoryDto()
        {
            Items = mapper.Map<List<MaintenanceHistoryRepositoryDto>>(
            await set
			.Where(x=> queryDto.Id_GT.HasValue ? x.Id > queryDto.Id_GT.Value : true)
            .Where(x=> queryDto.Id_GTE.HasValue ? x.Id >= queryDto.Id_GTE.Value : true)
            .Where(x=> queryDto.Id_LT.HasValue ? x.Id < queryDto.Id_LT.Value : true)
            .Where(x=> queryDto.Id_LTE.HasValue ? x.Id <= queryDto.Id_LTE.Value : true)
            .Where(x=> queryDto.Id_EQ.HasValue ? x.Id == queryDto.Id_EQ.Value : true)
			.Where(x=> queryDto.Date_GT.HasValue ? x.Date > queryDto.Date_GT.Value : true)
            .Where(x=> queryDto.Date_GTE.HasValue ? x.Date >= queryDto.Date_GTE.Value : true)
            .Where(x=> queryDto.Date_LT.HasValue ? x.Date < queryDto.Date_LT.Value : true)
            .Where(x=> queryDto.Date_LTE.HasValue ? x.Date <= queryDto.Date_LTE.Value : true)
            .Where(x=> queryDto.Date_EQ.HasValue ? x.Date == queryDto.Date_EQ.Value : true)
			.Where(x=> queryDto.VehicleId_GT.HasValue ? x.VehicleId > queryDto.VehicleId_GT.Value : true)
            .Where(x=> queryDto.VehicleId_GTE.HasValue ? x.VehicleId >= queryDto.VehicleId_GTE.Value : true)
            .Where(x=> queryDto.VehicleId_LT.HasValue ? x.VehicleId < queryDto.VehicleId_LT.Value : true)
            .Where(x=> queryDto.VehicleId_LTE.HasValue ? x.VehicleId <= queryDto.VehicleId_LTE.Value : true)
            .Where(x=> queryDto.VehicleId_EQ.HasValue ? x.VehicleId == queryDto.VehicleId_EQ.Value : true)

			.Where(x=> queryDto.MaintenanceTypeId_GT.HasValue ? x.MaintenanceTypeId > queryDto.MaintenanceTypeId_GT.Value : true)
            .Where(x=> queryDto.MaintenanceTypeId_GTE.HasValue ? x.MaintenanceTypeId >= queryDto.MaintenanceTypeId_GTE.Value : true)
            .Where(x=> queryDto.MaintenanceTypeId_LT.HasValue ? x.MaintenanceTypeId < queryDto.MaintenanceTypeId_LT.Value : true)
            .Where(x=> queryDto.MaintenanceTypeId_LTE.HasValue ? x.MaintenanceTypeId <= queryDto.MaintenanceTypeId_LTE.Value : true)
            .Where(x=> queryDto.MaintenanceTypeId_EQ.HasValue ? x.MaintenanceTypeId == queryDto.MaintenanceTypeId_EQ.Value : true)

			.Where(x=> !String.IsNullOrEmpty(queryDto.CompletedWork_EQ) ? x.CompletedWork == queryDto.CompletedWork_EQ : true)  
            .Where(x=> !String.IsNullOrEmpty(queryDto.CompletedWork_LIKE) ? (x.CompletedWork!=null?x.CompletedWork.Contains(queryDto.CompletedWork_LIKE):false) : true)
			.Where(x=> queryDto.AutomechanicId_GT.HasValue ? x.AutomechanicId > queryDto.AutomechanicId_GT.Value : true)
            .Where(x=> queryDto.AutomechanicId_GTE.HasValue ? x.AutomechanicId >= queryDto.AutomechanicId_GTE.Value : true)
            .Where(x=> queryDto.AutomechanicId_LT.HasValue ? x.AutomechanicId < queryDto.AutomechanicId_LT.Value : true)
            .Where(x=> queryDto.AutomechanicId_LTE.HasValue ? x.AutomechanicId <= queryDto.AutomechanicId_LTE.Value : true)
            .Where(x=> queryDto.AutomechanicId_EQ.HasValue ? x.AutomechanicId == queryDto.AutomechanicId_EQ.Value : true)
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<MaintenanceHistoryRepositoryDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<MaintenanceHistory,MaintenanceHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<MaintenanceHistory>(new {id});
        return mapper.Map<MaintenanceHistory,MaintenanceHistoryRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateMaintenanceHistoryRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<MaintenanceHistory>(new {Id = updateDto.Id});
		if(updateDto.Date.HasValue){
            entity.Date = updateDto.Date.Value;
        }
		if(updateDto.VehicleId.HasValue){
            entity.VehicleId = updateDto.VehicleId.Value;
        }

		if(updateDto.MaintenanceTypeId.HasValue){
            entity.MaintenanceTypeId = updateDto.MaintenanceTypeId.Value;
        }

		if(!String.IsNullOrEmpty(updateDto.CompletedWork)){
            entity.CompletedWork = updateDto.CompletedWork;
        }
		if(updateDto.AutomechanicId.HasValue){
            entity.AutomechanicId = updateDto.AutomechanicId.Value;
        }

        await db.SaveChangesAsync();
    }
}