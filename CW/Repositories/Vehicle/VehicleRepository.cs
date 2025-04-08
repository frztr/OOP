
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class VehicleRepository(AppDbContext db) : IVehicleRepository
{ 
    DbSet<Vehicle> set = db.Set<Vehicle>();
    public async Task<VehicleRepositoryDto> AddAsync(AddVehicleRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddVehicleRepositoryDto, Vehicle>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddVehicleRepositoryDto, Vehicle>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<Vehicle,VehicleRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<Vehicle,VehicleRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(int id)
    {
        set.Remove(await set.FirstOrDefaultAsync(x => x.Id == id));
        await db.SaveChangesAsync();
    }

    public async Task<VehicleListRepositoryDto> GetAllAsync(int count = 50, int offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Vehicle,VehicleRepositoryDto>());
        var mapper = new Mapper(config);
        return new VehicleListRepositoryDto()
        {
            Items = mapper.Map<List<VehicleRepositoryDto>>(
            await set.Skip(offset).Take(count < 50 ? count : 50).ToListAsync()
            )
        };
    }

    public async Task<VehicleRepositoryDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Vehicle,VehicleRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        return mapper.Map<Vehicle,VehicleRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateVehicleRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateVehicleRepositoryDto, Vehicle>());
        var mapper = new Mapper(config);
        mapper.Map<UpdateVehicleRepositoryDto, Vehicle>(updateDto,entity);
        db.SaveChangesAsync();
    }
}