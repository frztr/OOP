
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class VehicleModelRepository(AppDbContext db) : IVehicleModelRepository
{ 
    DbSet<VehicleModel> set = db.Set<VehicleModel>();
    public async Task<VehicleModelRepositoryDto> AddAsync(AddVehicleModelRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddVehicleModelRepositoryDto, VehicleModel>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddVehicleModelRepositoryDto, VehicleModel>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehicleModel,VehicleModelRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<VehicleModel,VehicleModelRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(int id)
    {
        set.Remove(await set.FirstOrDefaultAsync(x => x.Id == id));
        await db.SaveChangesAsync();
    }

    public async Task<VehicleModelListRepositoryDto> GetAllAsync(int count = 50, int offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleModel,VehicleModelRepositoryDto>());
        var mapper = new Mapper(config);
        return new VehicleModelListRepositoryDto()
        {
            Items = mapper.Map<List<VehicleModelRepositoryDto>>(
            await set.Skip(offset).Take(count < 50 ? count : 50).ToListAsync()
            )
        };
    }

    public async Task<VehicleModelRepositoryDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleModel,VehicleModelRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        return mapper.Map<VehicleModel,VehicleModelRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateVehicleModelRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateVehicleModelRepositoryDto, VehicleModel>());
        var mapper = new Mapper(config);
        mapper.Map<UpdateVehicleModelRepositoryDto, VehicleModel>(updateDto,entity);
        db.SaveChangesAsync();
    }
}