
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class RepairConsumedSparePartRepository(AppDbContext db) : IRepairConsumedSparePartRepository
{ 
    DbSet<RepairConsumedSparePart> set = db.Set<RepairConsumedSparePart>();
    public async Task<RepairConsumedSparePartRepositoryDto> AddAsync(AddRepairConsumedSparePartRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddRepairConsumedSparePartRepositoryDto, RepairConsumedSparePart>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddRepairConsumedSparePartRepositoryDto, RepairConsumedSparePart>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<RepairConsumedSparePart,RepairConsumedSparePartRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<RepairConsumedSparePart,RepairConsumedSparePartRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(int id)
    {
        set.Remove(await set.FirstOrDefaultAsync(x => x.Id == id));
        await db.SaveChangesAsync();
    }

    public async Task<RepairConsumedSparePartListRepositoryDto> GetAllAsync(int count = 50, int offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<RepairConsumedSparePart,RepairConsumedSparePartRepositoryDto>());
        var mapper = new Mapper(config);
        return new RepairConsumedSparePartListRepositoryDto()
        {
            Items = mapper.Map<List<RepairConsumedSparePartRepositoryDto>>(
            await set.Skip(offset).Take(count < 50 ? count : 50).ToListAsync()
            )
        };
    }

    public async Task<RepairConsumedSparePartRepositoryDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<RepairConsumedSparePart,RepairConsumedSparePartRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        return mapper.Map<RepairConsumedSparePart,RepairConsumedSparePartRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateRepairConsumedSparePartRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateRepairConsumedSparePartRepositoryDto, RepairConsumedSparePart>());
        var mapper = new Mapper(config);
        mapper.Map<UpdateRepairConsumedSparePartRepositoryDto, RepairConsumedSparePart>(updateDto,entity);
        db.SaveChangesAsync();
    }
}