
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class ManufacturerRepository(AppDbContext db) : IManufacturerRepository
{ 
    DbSet<Manufacturer> set = db.Set<Manufacturer>();
    public async Task<ManufacturerRepositoryDto> AddAsync(AddManufacturerRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddManufacturerRepositoryDto, Manufacturer>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddManufacturerRepositoryDto, Manufacturer>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<Manufacturer,ManufacturerRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<Manufacturer,ManufacturerRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(short id)
    {
        set.Remove(await set.FirstOrDefaultAsync(x => x.Id == id));
        await db.SaveChangesAsync();
    }

    public async Task<ManufacturerListRepositoryDto> GetAllAsync(short count = 50, short offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Manufacturer,ManufacturerRepositoryDto>());
        var mapper = new Mapper(config);
        return new ManufacturerListRepositoryDto()
        {
            Items = mapper.Map<List<ManufacturerRepositoryDto>>(
            await set.Skip(offset).Take(count < 50 ? count : 50).ToListAsync()
            )
        };
    }

    public async Task<ManufacturerRepositoryDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Manufacturer,ManufacturerRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        return mapper.Map<Manufacturer,ManufacturerRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateManufacturerRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateManufacturerRepositoryDto, Manufacturer>());
        var mapper = new Mapper(config);
        mapper.Map<UpdateManufacturerRepositoryDto, Manufacturer>(updateDto,entity);
        db.SaveChangesAsync();
    }
}