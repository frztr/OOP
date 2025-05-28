
using AutoMapper;
namespace Global;
using Microsoft.Extensions.Logging;
public class VehicleStatusService(IVehicleStatusRepository repository,

ILogger<VehicleStatusService> logger) : IVehicleStatusService
{
    public async Task<VehicleStatusServiceDto> AddAsync(AddVehicleStatusServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddVehicleStatusServiceDto, AddVehicleStatusRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddVehicleStatusServiceDto, AddVehicleStatusRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        );
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehicleStatusRepositoryDto, VehicleStatusServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<VehicleStatusRepositoryDto, VehicleStatusServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(short id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<VehicleStatusListServiceDto> GetAllAsync(VehicleStatusQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleStatusQueryServiceDto,VehicleStatusQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<VehicleStatusQueryServiceDto,VehicleStatusQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehicleStatusRepositoryDto,VehicleStatusServiceDto>());
        var mapper2 = new Mapper(config2);
        return new VehicleStatusListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<VehicleStatusServiceDto>(x))
        };
    }

    public async Task<VehicleStatusServiceDto> GetByIdAsync(short id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleStatusRepositoryDto, VehicleStatusServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<VehicleStatusRepositoryDto, VehicleStatusServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateVehicleStatusServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateVehicleStatusServiceDto, UpdateVehicleStatusRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateVehicleStatusServiceDto, UpdateVehicleStatusRepositoryDto>(updateDto);
        await Task.WhenAll(
        );
        await repository.UpdateAsync(updateRepositoryDto);
    }
}