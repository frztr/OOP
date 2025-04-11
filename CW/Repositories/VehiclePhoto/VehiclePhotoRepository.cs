
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

    public async Task<VehiclePhotoListRepositoryDto> GetAllAsync(VehiclePhotoQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehiclePhoto,VehiclePhotoRepositoryDto>());
        var mapper = new Mapper(config);
        return new VehiclePhotoListRepositoryDto()
        {
            Items = mapper.Map<List<VehiclePhotoRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
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
		if(!String.IsNullOrEmpty(updateDto.Src)){
            entity.Src = updateDto.Src;
        }
		if(updateDto.VehicleId.HasValue){
            entity.VehicleId = updateDto.VehicleId.Value;
        }

        await db.SaveChangesAsync();
    }
}