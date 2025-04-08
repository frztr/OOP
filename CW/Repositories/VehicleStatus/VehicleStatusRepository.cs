
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class VehicleStatusRepository(AppDbContext db) : IVehicleStatusRepository
{ 
    DbSet<VehicleStatus> set = db.Set<VehicleStatus>();
    public async Task<VehicleStatusRepositoryDto> AddAsync(AddVehicleStatusRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddVehicleStatusRepositoryDto, VehicleStatus>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddVehicleStatusRepositoryDto, VehicleStatus>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehicleStatus,VehicleStatusRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<VehicleStatus,VehicleStatusRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(short id)
    {
        set.Remove(await set.FirstOrDefaultAsync(x => x.Id == id));
        await db.SaveChangesAsync();
    }

    public async Task<VehicleStatusListRepositoryDto> GetAllAsync(short count = 50, short offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleStatus,VehicleStatusRepositoryDto>());
        var mapper = new Mapper(config);
        return new VehicleStatusListRepositoryDto()
        {
            Items = mapper.Map<List<VehicleStatusRepositoryDto>>(
            await set.Skip(offset).Take(count < 50 ? count : 50).ToListAsync()
            )
        };
    }

    public async Task<VehicleStatusRepositoryDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleStatus,VehicleStatusRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        return mapper.Map<VehicleStatus,VehicleStatusRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateVehicleStatusRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateVehicleStatusRepositoryDto, VehicleStatus>());
        var mapper = new Mapper(config);
        mapper.Map<UpdateVehicleStatusRepositoryDto, VehicleStatus>(updateDto,entity);
        db.SaveChangesAsync();
    }
}