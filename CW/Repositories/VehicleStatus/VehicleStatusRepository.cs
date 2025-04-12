
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
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<VehicleStatus>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<VehicleStatusListRepositoryDto> GetAllAsync(VehicleStatusQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleStatus,VehicleStatusRepositoryDto>());
        var mapper = new Mapper(config);
        return new VehicleStatusListRepositoryDto()
        {
            Items = mapper.Map<List<VehicleStatusRepositoryDto>>(
            await set
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<VehicleStatusRepositoryDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleStatus,VehicleStatusRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<VehicleStatus>(new {id});
        return mapper.Map<VehicleStatus,VehicleStatusRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateVehicleStatusRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<VehicleStatus>(new {Id = updateDto.Id});
		if(!String.IsNullOrEmpty(updateDto.Name)){
            entity.Name = updateDto.Name;
        }
        await db.SaveChangesAsync();
    }
}