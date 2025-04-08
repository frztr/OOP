
using AutoMapper;
namespace Global;
public class VehicleCategoryService(IVehicleCategoryRepository repository) : IVehicleCategoryService
{
    public async Task<VehicleCategoryServiceDto> AddAsync(AddVehicleCategoryServiceDto addServiceDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddVehicleCategoryServiceDto, AddVehicleCategoryRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddVehicleCategoryServiceDto, AddVehicleCategoryRepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehicleCategoryRepositoryDto, VehicleCategoryServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<VehicleCategoryRepositoryDto, VehicleCategoryServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(short id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<VehicleCategoryListServiceDto> GetAllAsync(short count = 50, short offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleCategoryRepositoryDto,VehicleCategoryServiceDto>());
        var mapper = new Mapper(config);
        return new VehicleCategoryListServiceDto(){
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<VehicleCategoryServiceDto>(x))
        };
    }

    public async Task<VehicleCategoryServiceDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleCategoryRepositoryDto, VehicleCategoryServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<VehicleCategoryRepositoryDto, VehicleCategoryServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateVehicleCategoryServiceDto updateDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateVehicleCategoryServiceDto, UpdateVehicleCategoryRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateVehicleCategoryServiceDto, UpdateVehicleCategoryRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}