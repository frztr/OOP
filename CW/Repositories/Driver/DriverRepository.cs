
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class DriverRepository(AppDbContext db) : IDriverRepository
{ 
    DbSet<Driver> set = db.Set<Driver>();
    public async Task<DriverRepositoryDto> AddAsync(AddDriverRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddDriverRepositoryDto, Driver>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddDriverRepositoryDto, Driver>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<Driver,DriverRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<Driver,DriverRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(short id)
    {
        set.Remove(await set.FirstOrDefaultAsync(x => x.Id == id));
        await db.SaveChangesAsync();
    }

    public async Task<DriverListRepositoryDto> GetAllAsync(short count = 50, short offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Driver,DriverRepositoryDto>());
        var mapper = new Mapper(config);
        return new DriverListRepositoryDto()
        {
            Items = mapper.Map<List<DriverRepositoryDto>>(
            await set.Skip(offset).Take(count < 50 ? count : 50).ToListAsync()
            )
        };
    }

    public async Task<DriverRepositoryDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Driver,DriverRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        return mapper.Map<Driver,DriverRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateDriverRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateDriverRepositoryDto, Driver>());
        var mapper = new Mapper(config);
        mapper.Map<UpdateDriverRepositoryDto, Driver>(updateDto,entity);
        db.SaveChangesAsync();
    }
}