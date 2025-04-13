
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
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<VehicleModel>(new {id});
        set.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<VehicleModelListRepositoryDto> GetAllAsync(VehicleModelQueryRepositoryDto queryDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleModel,VehicleModelRepositoryDto>());
        var mapper = new Mapper(config);
        return new VehicleModelListRepositoryDto()
        {
            Items = mapper.Map<List<VehicleModelRepositoryDto>>(
            await set
			.Where(x=> queryDto.Id_GT.HasValue ? x.Id > queryDto.Id_GT.Value : true)
            .Where(x=> queryDto.Id_GTE.HasValue ? x.Id >= queryDto.Id_GTE.Value : true)
            .Where(x=> queryDto.Id_LT.HasValue ? x.Id < queryDto.Id_LT.Value : true)
            .Where(x=> queryDto.Id_LTE.HasValue ? x.Id <= queryDto.Id_LTE.Value : true)
            .Where(x=> queryDto.Id_EQ.HasValue ? x.Id == queryDto.Id_EQ.Value : true)
			.Where(x=> !String.IsNullOrEmpty(queryDto.Name_EQ) ? x.Name == queryDto.Name_EQ : true)  
            .Where(x=> !String.IsNullOrEmpty(queryDto.Name_LIKE) ? (x.Name!=null?x.Name.Contains(queryDto.Name_LIKE):false) : true)
			.Where(x=> queryDto.ManufacturerId_GT.HasValue ? x.ManufacturerId > queryDto.ManufacturerId_GT.Value : true)
            .Where(x=> queryDto.ManufacturerId_GTE.HasValue ? x.ManufacturerId >= queryDto.ManufacturerId_GTE.Value : true)
            .Where(x=> queryDto.ManufacturerId_LT.HasValue ? x.ManufacturerId < queryDto.ManufacturerId_LT.Value : true)
            .Where(x=> queryDto.ManufacturerId_LTE.HasValue ? x.ManufacturerId <= queryDto.ManufacturerId_LTE.Value : true)
            .Where(x=> queryDto.ManufacturerId_EQ.HasValue ? x.ManufacturerId == queryDto.ManufacturerId_EQ.Value : true)

			.Where(x=> queryDto.VehicleCategoryId_GT.HasValue ? x.VehicleCategoryId > queryDto.VehicleCategoryId_GT.Value : true)
            .Where(x=> queryDto.VehicleCategoryId_GTE.HasValue ? x.VehicleCategoryId >= queryDto.VehicleCategoryId_GTE.Value : true)
            .Where(x=> queryDto.VehicleCategoryId_LT.HasValue ? x.VehicleCategoryId < queryDto.VehicleCategoryId_LT.Value : true)
            .Where(x=> queryDto.VehicleCategoryId_LTE.HasValue ? x.VehicleCategoryId <= queryDto.VehicleCategoryId_LTE.Value : true)
            .Where(x=> queryDto.VehicleCategoryId_EQ.HasValue ? x.VehicleCategoryId == queryDto.VehicleCategoryId_EQ.Value : true)

			.Where(x=> queryDto.Power_GT.HasValue ? x.Power > queryDto.Power_GT.Value : true)
            .Where(x=> queryDto.Power_GTE.HasValue ? x.Power >= queryDto.Power_GTE.Value : true)
            .Where(x=> queryDto.Power_LT.HasValue ? x.Power < queryDto.Power_LT.Value : true)
            .Where(x=> queryDto.Power_LTE.HasValue ? x.Power <= queryDto.Power_LTE.Value : true)
            .Where(x=> queryDto.Power_EQ.HasValue ? x.Power == queryDto.Power_EQ.Value : true)
			.Where(x=> queryDto.FuelTypeId_GT.HasValue ? x.FuelTypeId > queryDto.FuelTypeId_GT.Value : true)
            .Where(x=> queryDto.FuelTypeId_GTE.HasValue ? x.FuelTypeId >= queryDto.FuelTypeId_GTE.Value : true)
            .Where(x=> queryDto.FuelTypeId_LT.HasValue ? x.FuelTypeId < queryDto.FuelTypeId_LT.Value : true)
            .Where(x=> queryDto.FuelTypeId_LTE.HasValue ? x.FuelTypeId <= queryDto.FuelTypeId_LTE.Value : true)
            .Where(x=> queryDto.FuelTypeId_EQ.HasValue ? x.FuelTypeId == queryDto.FuelTypeId_EQ.Value : true)

			.Where(x=> queryDto.LoadCapacity_GT.HasValue ? x.LoadCapacity > queryDto.LoadCapacity_GT.Value : true)
            .Where(x=> queryDto.LoadCapacity_GTE.HasValue ? x.LoadCapacity >= queryDto.LoadCapacity_GTE.Value : true)
            .Where(x=> queryDto.LoadCapacity_LT.HasValue ? x.LoadCapacity < queryDto.LoadCapacity_LT.Value : true)
            .Where(x=> queryDto.LoadCapacity_LTE.HasValue ? x.LoadCapacity <= queryDto.LoadCapacity_LTE.Value : true)
            .Where(x=> queryDto.LoadCapacity_EQ.HasValue ? x.LoadCapacity == queryDto.LoadCapacity_EQ.Value : true)
.Skip(queryDto.Offset).Take(queryDto.Count < 50 ? queryDto.Count : 50).ToListAsync()
            )
        };
    }

    public async Task<VehicleModelRepositoryDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleModel,VehicleModelRepositoryDto>());
        var mapper = new Mapper(config);
        var entity = await set.FirstOrDefaultAsync(x => x.Id == id);
        if(entity == null) throw new EntityNotFoundException<VehicleModel>(new {id});
        return mapper.Map<VehicleModel,VehicleModelRepositoryDto>(entity);
    }

    public async Task UpdateAsync(UpdateVehicleModelRepositoryDto updateDto)
    {
        var entity = await set.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if(entity == null) throw new EntityNotFoundException<VehicleModel>(new {Id = updateDto.Id});
		if(!String.IsNullOrEmpty(updateDto.Name)){
            entity.Name = updateDto.Name;
        }
		if(updateDto.ManufacturerId.HasValue){
            entity.ManufacturerId = updateDto.ManufacturerId.Value;
        }

		if(updateDto.VehicleCategoryId.HasValue){
            entity.VehicleCategoryId = updateDto.VehicleCategoryId.Value;
        }

		if(updateDto.Power.HasValue){
            entity.Power = updateDto.Power.Value;
        }
		if(updateDto.FuelTypeId.HasValue){
            entity.FuelTypeId = updateDto.FuelTypeId.Value;
        }

		if(updateDto.LoadCapacity.HasValue){
            entity.LoadCapacity = updateDto.LoadCapacity.Value;
        }

        await db.SaveChangesAsync();
    }
}