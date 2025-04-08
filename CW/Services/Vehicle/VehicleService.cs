
using AutoMapper;
namespace Global;
public class VehicleService(IVehicleRepository repository) : IVehicleService
{
    public async Task<VehicleServiceDto> AddAsync(AddVehicleServiceDto addServiceDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddVehicleServiceDto, AddVehicleRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddVehicleServiceDto, AddVehicleRepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehicleRepositoryDto, VehicleServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<VehicleRepositoryDto, VehicleServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(int id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<VehicleListServiceDto> GetAllAsync(int count = 50, int offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleRepositoryDto,VehicleServiceDto>());
        var mapper = new Mapper(config);
        return new VehicleListServiceDto(){
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<VehicleServiceDto>(x))
        };
    }

    public async Task<VehicleServiceDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleRepositoryDto, VehicleServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<VehicleRepositoryDto, VehicleServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateVehicleServiceDto updateDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateVehicleServiceDto, UpdateVehicleRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateVehicleServiceDto, UpdateVehicleRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}