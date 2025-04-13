
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class PlannedMaintenanceScheduleRepository(AppDbContext db) : IPlannedMaintenanceScheduleRepository
{ 
    DbSet<PlannedMaintenanceSchedule> set = db.Set<PlannedMaintenanceSchedule>();
    public async Task<PlannedMaintenanceScheduleRepositoryDto> AddAsync(AddPlannedMaintenanceScheduleRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddPlannedMaintenanceScheduleRepositoryDto, PlannedMaintenanceSchedule>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddPlannedMaintenanceScheduleRepositoryDto, PlannedMaintenanceSchedule>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<PlannedMaintenanceSchedule,PlannedMaintenanceScheduleRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<PlannedMaintenanceSchedule,PlannedMaintenanceScheduleRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<PlannedMaintenanceSchedule>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<PlannedMaintenanceScheduleListRepositoryDto> GetAllAsync(PlannedMaintenanceScheduleQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<PlannedMaintenanceSchedule,PlannedMaintenanceScheduleRepositoryDto>());
        var mapper = new Mapper(config);
        return new PlannedMaintenanceScheduleListRepositoryDto()
        {
            Items = mapper.Map<List<PlannedMaintenanceScheduleRepositoryDto>>(
            await set
			.Where(x=> queryDto.Id_GT.HasValue ? x.Id > queryDto.Id_GT.Value : true)
            .Where(x=> queryDto.Id_GTE.HasValue ? x.Id >= queryDto.Id_GTE.Value : true)
            .Where(x=> queryDto.Id_LT.HasValue ? x.Id < queryDto.Id_LT.Value : true)
            .Where(x=> queryDto.Id_LTE.HasValue ? x.Id <= queryDto.Id_LTE.Value : true)
            .Where(x=> queryDto.Id_EQ.HasValue ? x.Id == queryDto.Id_EQ.Value : true)
			.Where(x=> queryDto.PlannedDate_GT.HasValue ? x.PlannedDate > queryDto.PlannedDate_GT.Value : true)
            .Where(x=> queryDto.PlannedDate_GTE.HasValue ? x.PlannedDate >= queryDto.PlannedDate_GTE.Value : true)
            .Where(x=> queryDto.PlannedDate_LT.HasValue ? x.PlannedDate < queryDto.PlannedDate_LT.Value : true)
            .Where(x=> queryDto.PlannedDate_LTE.HasValue ? x.PlannedDate <= queryDto.PlannedDate_LTE.Value : true)
            .Where(x=> queryDto.PlannedDate_EQ.HasValue ? x.PlannedDate == queryDto.PlannedDate_EQ.Value : true)
			.Where(x=> queryDto.MaintenanceTypeId_GT.HasValue ? x.MaintenanceTypeId > queryDto.MaintenanceTypeId_GT.Value : true)
            .Where(x=> queryDto.MaintenanceTypeId_GTE.HasValue ? x.MaintenanceTypeId >= queryDto.MaintenanceTypeId_GTE.Value : true)
            .Where(x=> queryDto.MaintenanceTypeId_LT.HasValue ? x.MaintenanceTypeId < queryDto.MaintenanceTypeId_LT.Value : true)
            .Where(x=> queryDto.MaintenanceTypeId_LTE.HasValue ? x.MaintenanceTypeId <= queryDto.MaintenanceTypeId_LTE.Value : true)
            .Where(x=> queryDto.MaintenanceTypeId_EQ.HasValue ? x.MaintenanceTypeId == queryDto.MaintenanceTypeId_EQ.Value : true)

			.Where(x=> queryDto.VehicleId_GT.HasValue ? x.VehicleId > queryDto.VehicleId_GT.Value : true)
            .Where(x=> queryDto.VehicleId_GTE.HasValue ? x.VehicleId >= queryDto.VehicleId_GTE.Value : true)
            .Where(x=> queryDto.VehicleId_LT.HasValue ? x.VehicleId < queryDto.VehicleId_LT.Value : true)
            .Where(x=> queryDto.VehicleId_LTE.HasValue ? x.VehicleId <= queryDto.VehicleId_LTE.Value : true)
            .Where(x=> queryDto.VehicleId_EQ.HasValue ? x.VehicleId == queryDto.VehicleId_EQ.Value : true)
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<PlannedMaintenanceScheduleRepositoryDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<PlannedMaintenanceSchedule,PlannedMaintenanceScheduleRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<PlannedMaintenanceSchedule>(new {id});
        return mapper.Map<PlannedMaintenanceSchedule,PlannedMaintenanceScheduleRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdatePlannedMaintenanceScheduleRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<PlannedMaintenanceSchedule>(new {Id = updateDto.Id});
		if(updateDto.PlannedDate.HasValue){
            entity.PlannedDate = updateDto.PlannedDate.Value;
        }
		if(updateDto.MaintenanceTypeId.HasValue){
            entity.MaintenanceTypeId = updateDto.MaintenanceTypeId.Value;
        }

		if(updateDto.VehicleId.HasValue){
            entity.VehicleId = updateDto.VehicleId.Value;
        }

        await db.SaveChangesAsync();
    }
}