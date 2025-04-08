
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Global;
public class VehiclePhotoRepository(AppDbContext db) : IVehiclePhotoRepository
{ 
    DbSet<VehiclePhoto> set = db.Set<VehiclePhoto>();
    public async Task<VehiclePhotoRepositoryDto> AddAsync(AddVehiclePhotoRepositoryDto addDto)
    {  
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddVehiclePhotoRepositoryDto, VehiclePhoto>());
        var mapper = new Mapper(config);
        var entity = mapper.Map<AddVehiclePhotoRepositoryDto, VehiclePhoto>(addDto);
        await set.AddAsync(entity);
        await db.SaveChangesAsync();
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehiclePhoto,VehiclePhotoRepositoryDto>());
        var mapper2 = new Mapper(config2);
        var dto = mapper2.Map<VehiclePhoto,VehiclePhotoRepositoryDto>(entity);
        return dto;
    }

    public async Task DeleteAsync(int id)
    {
        set.Remove(await set.FirstOrDefaultAsync(x => x.Id == id));
        await db.SaveChangesAsync();
    }

    public async Task<VehiclePhotoListRepositoryDto> GetAllAsync(int count = 50, int offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehiclePhoto,VehiclePhotoRepositoryDto>());
        var mapper = new Mapper(config);
        return new VehiclePhotoListRepositoryDto()
        {
            Items = mapper.Map<List<VehiclePhotoRepositoryDto>>(
            await set.Skip(offset).Take(count < 50 ? count : 50).ToListAsync()
            )
        };
    }

    public async Task<VehiclePhotoRepositoryDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehiclePhoto,VehiclePhotoRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        return mapper.Map<VehiclePhoto,VehiclePhotoRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateVehiclePhotoRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateVehiclePhotoRepositoryDto, VehiclePhoto>());
        var mapper = new Mapper(config);
        mapper.Map<UpdateVehiclePhotoRepositoryDto, VehiclePhoto>(updateDto,entity);
        db.SaveChangesAsync();
    }
}