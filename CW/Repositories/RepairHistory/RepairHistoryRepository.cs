
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class RepairHistoryRepository(AppDbContext db) : IRepairHistoryRepository
{ 
    DbSet<RepairHistory> set = db.Set<RepairHistory>();
    public async Task<RepairHistoryRepositoryDto> AddAsync(AddRepairHistoryRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddRepairHistoryRepositoryDto, RepairHistory>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddRepairHistoryRepositoryDto, RepairHistory>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<RepairHistory,RepairHistoryRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<RepairHistory,RepairHistoryRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(int id)
    {
        set.Remove(await set.FirstOrDefaultAsync(x => x.Id == id));
        await db.SaveChangesAsync();
    }

    public async Task<RepairHistoryListRepositoryDto> GetAllAsync(int count = 50, int offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<RepairHistory,RepairHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        return new RepairHistoryListRepositoryDto()
        {
            Items = mapper.Map<List<RepairHistoryRepositoryDto>>(
            await set.Skip(offset).Take(count < 50 ? count : 50).ToListAsync()
            )
        };
    }

    public async Task<RepairHistoryRepositoryDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<RepairHistory,RepairHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        return mapper.Map<RepairHistory,RepairHistoryRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateRepairHistoryRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateRepairHistoryRepositoryDto, RepairHistory>());
        var mapper = new Mapper(config);
        mapper.Map<UpdateRepairHistoryRepositoryDto, RepairHistory>(updateDto,entity);
        db.SaveChangesAsync();
    }
}