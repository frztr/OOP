
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
        set.Remove(await set.FirstOrDefaultAsync(x => x.Id == id));
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
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<MaintenanceHistoryRepositoryDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<MaintenanceHistory,MaintenanceHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        return mapper.Map<MaintenanceHistory,MaintenanceHistoryRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateMaintenanceHistoryRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateMaintenanceHistoryRepositoryDto, MaintenanceHistory>());
        var mapper = new Mapper(config);
        mapper.Map<UpdateMaintenanceHistoryRepositoryDto, MaintenanceHistory>(updateDto,entity);
        db.SaveChangesAsync();
    }
}