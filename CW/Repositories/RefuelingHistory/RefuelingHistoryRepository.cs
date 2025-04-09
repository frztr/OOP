
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
        set.Remove(await set.FirstOrDefaultAsync(x => x.Id == id));
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
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<RefuelingHistoryRepositoryDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<RefuelingHistory,RefuelingHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        return mapper.Map<RefuelingHistory,RefuelingHistoryRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateRefuelingHistoryRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateRefuelingHistoryRepositoryDto, RefuelingHistory>());
        var mapper = new Mapper(config);
        mapper.Map<UpdateRefuelingHistoryRepositoryDto, RefuelingHistory>(updateDto,entity);
        db.SaveChangesAsync();
    }
}