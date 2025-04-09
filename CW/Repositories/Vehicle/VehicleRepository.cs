
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

    public async Task<VehicleListRepositoryDto> GetAllAsync(VehicleQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Vehicle,VehicleRepositoryDto>());
        var mapper = new Mapper(config);
        return new VehicleListRepositoryDto()
        {
            Items = mapper.Map<List<VehicleRepositoryDto>>(
            await set
			.Where(x=> queryDto.Id_GT.HasValue ? x.Id > queryDto.Id_GT.Value : true)
            .Where(x=> queryDto.Id_GTE.HasValue ? x.Id >= queryDto.Id_GTE.Value : true)
            .Where(x=> queryDto.Id_LT.HasValue ? x.Id < queryDto.Id_LT.Value : true)
            .Where(x=> queryDto.Id_LTE.HasValue ? x.Id <= queryDto.Id_LTE.Value : true)
            .Where(x=> queryDto.Id_EQ.HasValue ? x.Id == queryDto.Id_EQ.Value : true)
			.Where(x=> !String.IsNullOrEmpty(queryDto.VinNumber_EQ) ? x.VinNumber == queryDto.VinNumber_EQ : true)  
            .Where(x=> !String.IsNullOrEmpty(queryDto.VinNumber_LIKE) ? (x.VinNumber!=null?x.VinNumber.Contains(queryDto.VinNumber_LIKE):false) : true)
			.Where(x=> !String.IsNullOrEmpty(queryDto.PlateNumber_EQ) ? x.PlateNumber == queryDto.PlateNumber_EQ : true)  
            .Where(x=> !String.IsNullOrEmpty(queryDto.PlateNumber_LIKE) ? (x.PlateNumber!=null?x.PlateNumber.Contains(queryDto.PlateNumber_LIKE):false) : true)
			.Where(x=> queryDto.VehicleModelId_GT.HasValue ? x.VehicleModelId > queryDto.VehicleModelId_GT.Value : true)
            .Where(x=> queryDto.VehicleModelId_GTE.HasValue ? x.VehicleModelId >= queryDto.VehicleModelId_GTE.Value : true)
            .Where(x=> queryDto.VehicleModelId_LT.HasValue ? x.VehicleModelId < queryDto.VehicleModelId_LT.Value : true)
            .Where(x=> queryDto.VehicleModelId_LTE.HasValue ? x.VehicleModelId <= queryDto.VehicleModelId_LTE.Value : true)
            .Where(x=> queryDto.VehicleModelId_EQ.HasValue ? x.VehicleModelId == queryDto.VehicleModelId_EQ.Value : true)
			.Where(x=> queryDto.ReleaseYear_GT.HasValue ? x.ReleaseYear > queryDto.ReleaseYear_GT.Value : true)
            .Where(x=> queryDto.ReleaseYear_GTE.HasValue ? x.ReleaseYear >= queryDto.ReleaseYear_GTE.Value : true)
            .Where(x=> queryDto.ReleaseYear_LT.HasValue ? x.ReleaseYear < queryDto.ReleaseYear_LT.Value : true)
            .Where(x=> queryDto.ReleaseYear_LTE.HasValue ? x.ReleaseYear <= queryDto.ReleaseYear_LTE.Value : true)
            .Where(x=> queryDto.ReleaseYear_EQ.HasValue ? x.ReleaseYear == queryDto.ReleaseYear_EQ.Value : true)
			.Where(x=> queryDto.RegistrationDate_GT.HasValue ? x.RegistrationDate > queryDto.RegistrationDate_GT.Value : true)
            .Where(x=> queryDto.RegistrationDate_GTE.HasValue ? x.RegistrationDate >= queryDto.RegistrationDate_GTE.Value : true)
            .Where(x=> queryDto.RegistrationDate_LT.HasValue ? x.RegistrationDate < queryDto.RegistrationDate_LT.Value : true)
            .Where(x=> queryDto.RegistrationDate_LTE.HasValue ? x.RegistrationDate <= queryDto.RegistrationDate_LTE.Value : true)
            .Where(x=> queryDto.RegistrationDate_EQ.HasValue ? x.RegistrationDate == queryDto.RegistrationDate_EQ.Value : true)
			.Where(x=> queryDto.StatusId_GT.HasValue ? x.StatusId > queryDto.StatusId_GT.Value : true)
            .Where(x=> queryDto.StatusId_GTE.HasValue ? x.StatusId >= queryDto.StatusId_GTE.Value : true)
            .Where(x=> queryDto.StatusId_LT.HasValue ? x.StatusId < queryDto.StatusId_LT.Value : true)
            .Where(x=> queryDto.StatusId_LTE.HasValue ? x.StatusId <= queryDto.StatusId_LTE.Value : true)
            .Where(x=> queryDto.StatusId_EQ.HasValue ? x.StatusId == queryDto.StatusId_EQ.Value : true)

.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
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