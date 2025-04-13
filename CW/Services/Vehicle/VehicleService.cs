
using AutoMapper;
namespace Global;
public class VehicleService(IVehicleRepository repository,
IVehicleModelRepository vehicleModelRepository,
IVehicleStatusRepository vehicleStatusRepository,
ILogger<VehicleService> logger) : IVehicleService
{
    public async Task<VehicleServiceDto> AddAsync(AddVehicleServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddVehicleServiceDto, AddVehicleRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddVehicleServiceDto, AddVehicleRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        vehicleModelRepository.GetByIdAsync(addRepositoryDto.VehiclemodelId),
		vehicleStatusRepository.GetByIdAsync(addRepositoryDto.StatusId));
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehicleRepositoryDto, VehicleServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<VehicleRepositoryDto, VehicleServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(int id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<VehicleListServiceDto> GetAllAsync(VehicleQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleQueryServiceDto,VehicleQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<VehicleQueryServiceDto,VehicleQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehicleRepositoryDto,VehicleServiceDto>());
        var mapper2 = new Mapper(config2);
        return new VehicleListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<VehicleServiceDto>(x))
        };
    }

    public async Task<VehicleServiceDto> GetByIdAsync(int id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleRepositoryDto, VehicleServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<VehicleRepositoryDto, VehicleServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateVehicleServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateVehicleServiceDto, UpdateVehicleRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateVehicleServiceDto, UpdateVehicleRepositoryDto>(updateDto);
        await Task.WhenAll(
        updateDto.VehiclemodelId.HasValue ? vehicleModelRepository.GetByIdAsync(updateDto.VehiclemodelId.Value) : Task.CompletedTask,
		updateDto.StatusId.HasValue ? vehicleStatusRepository.GetByIdAsync(updateDto.StatusId.Value) : Task.CompletedTask);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}