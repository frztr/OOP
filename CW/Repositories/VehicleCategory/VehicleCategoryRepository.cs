
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class VehicleCategoryRepository(AppDbContext db) : IVehicleCategoryRepository
{ 
    DbSet<VehicleCategory> set = db.Set<VehicleCategory>();
    public async Task<VehicleCategoryRepositoryDto> AddAsync(AddVehicleCategoryRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddVehicleCategoryRepositoryDto, VehicleCategory>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddVehicleCategoryRepositoryDto, VehicleCategory>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehicleCategory,VehicleCategoryRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<VehicleCategory,VehicleCategoryRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(short id)
    {
        set.Remove(await set.FirstOrDefaultAsync(x => x.Id == id));
        await db.SaveChangesAsync();
    }

    public async Task<VehicleCategoryListRepositoryDto> GetAllAsync(short count = 50, short offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleCategory,VehicleCategoryRepositoryDto>());
        var mapper = new Mapper(config);
        return new VehicleCategoryListRepositoryDto()
        {
            Items = mapper.Map<List<VehicleCategoryRepositoryDto>>(
            await set.Skip(offset).Take(count < 50 ? count : 50).ToListAsync()
            )
        };
    }

    public async Task<VehicleCategoryRepositoryDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleCategory,VehicleCategoryRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        return mapper.Map<VehicleCategory,VehicleCategoryRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateVehicleCategoryRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateVehicleCategoryRepositoryDto, VehicleCategory>());
        var mapper = new Mapper(config);
        mapper.Map<UpdateVehicleCategoryRepositoryDto, VehicleCategory>(updateDto,entity);
        db.SaveChangesAsync();
    }
}