
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
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<Vehicle>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<VehicleListRepositoryDto> GetAllAsync(VehicleQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Vehicle,VehicleRepositoryDto>());
        var mapper = new Mapper(config);
        return new VehicleListRepositoryDto()
        {
            Items = mapper.Map<List<VehicleRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<VehicleRepositoryDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Vehicle,VehicleRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<Vehicle>(new {id});
        return mapper.Map<Vehicle,VehicleRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateVehicleRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<Vehicle>(new {Id = updateDto.Id});
		if(!String.IsNullOrEmpty(updateDto.VinNumber)){
            entity.VinNumber = updateDto.VinNumber;
        }
		if(!String.IsNullOrEmpty(updateDto.PlateNumber)){
            entity.PlateNumber = updateDto.PlateNumber;
        }
		if(updateDto.VehiclemodelId.HasValue){
            entity.VehiclemodelId = updateDto.VehiclemodelId.Value;
        }

		if(updateDto.ReleaseYear.HasValue){
            entity.ReleaseYear = updateDto.ReleaseYear.Value;
        }
		if(updateDto.RegistrationDate.HasValue){
            entity.RegistrationDate = updateDto.RegistrationDate.Value;
        }
		if(updateDto.StatusId.HasValue){
            entity.StatusId = updateDto.StatusId.Value;
        }









        await db.SaveChangesAsync();
    }
}