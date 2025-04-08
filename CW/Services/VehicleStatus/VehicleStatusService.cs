
using AutoMapper;
namespace Global;
public class VehicleStatusService(IVehicleStatusRepository repository) : IVehicleStatusService
{
    public async Task<VehicleStatusServiceDto> AddAsync(AddVehicleStatusServiceDto addServiceDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddVehicleStatusServiceDto, AddVehicleStatusRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddVehicleStatusServiceDto, AddVehicleStatusRepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehicleStatusRepositoryDto, VehicleStatusServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<VehicleStatusRepositoryDto, VehicleStatusServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(short id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<VehicleStatusListServiceDto> GetAllAsync(short count = 50, short offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleStatusRepositoryDto,VehicleStatusServiceDto>());
        var mapper = new Mapper(config);
        return new VehicleStatusListServiceDto(){
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<VehicleStatusServiceDto>(x))
        };
    }

    public async Task<VehicleStatusServiceDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleStatusRepositoryDto, VehicleStatusServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<VehicleStatusRepositoryDto, VehicleStatusServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateVehicleStatusServiceDto updateDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateVehicleStatusServiceDto, UpdateVehicleStatusRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateVehicleStatusServiceDto, UpdateVehicleStatusRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}