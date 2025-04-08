
using AutoMapper;
namespace Global;
public class VehicleModelService(IVehicleModelRepository repository) : IVehicleModelService
{
    public async Task<VehicleModelServiceDto> AddAsync(AddVehicleModelServiceDto addServiceDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddVehicleModelServiceDto, AddVehicleModelRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddVehicleModelServiceDto, AddVehicleModelRepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehicleModelRepositoryDto, VehicleModelServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<VehicleModelRepositoryDto, VehicleModelServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(int id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<VehicleModelListServiceDto> GetAllAsync(int count = 50, int offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleModelRepositoryDto,VehicleModelServiceDto>());
        var mapper = new Mapper(config);
        return new VehicleModelListServiceDto(){
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<VehicleModelServiceDto>(x))
        };
    }

    public async Task<VehicleModelServiceDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleModelRepositoryDto, VehicleModelServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<VehicleModelRepositoryDto, VehicleModelServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateVehicleModelServiceDto updateDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateVehicleModelServiceDto, UpdateVehicleModelRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateVehicleModelServiceDto, UpdateVehicleModelRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}