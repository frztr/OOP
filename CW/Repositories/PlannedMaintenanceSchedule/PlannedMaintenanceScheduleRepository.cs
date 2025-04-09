
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
        set.Remove(await set.FirstOrDefaultAsync(x => x.Id == id));
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
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<PlannedMaintenanceScheduleRepositoryDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<PlannedMaintenanceSchedule,PlannedMaintenanceScheduleRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        return mapper.Map<PlannedMaintenanceSchedule,PlannedMaintenanceScheduleRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdatePlannedMaintenanceScheduleRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdatePlannedMaintenanceScheduleRepositoryDto, PlannedMaintenanceSchedule>());
        var mapper = new Mapper(config);
        mapper.Map<UpdatePlannedMaintenanceScheduleRepositoryDto, PlannedMaintenanceSchedule>(updateDto,entity);
        db.SaveChangesAsync();
    }
}