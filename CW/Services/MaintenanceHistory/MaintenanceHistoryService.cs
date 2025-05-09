
using AutoMapper;
namespace Global;
using Microsoft.Extensions.Logging;
public class MaintenanceHistoryService(IMaintenanceHistoryRepository repository,
IVehicleRepository vehicleRepository,
IMaintenanceTypeRepository maintenanceTypeRepository,
IAutomechanicRepository automechanicRepository,
ILogger<MaintenanceHistoryService> logger) : IMaintenanceHistoryService
{
    public async Task<MaintenanceHistoryServiceDto> AddAsync(AddMaintenanceHistoryServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddMaintenanceHistoryServiceDto, AddMaintenanceHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddMaintenanceHistoryServiceDto, AddMaintenanceHistoryRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        vehicleRepository.GetByIdAsync(addRepositoryDto.VehicleId),
		maintenanceTypeRepository.GetByIdAsync(addRepositoryDto.MaintenanceTypeId),
		automechanicRepository.GetByIdAsync(addRepositoryDto.AutomechanicId));
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<MaintenanceHistoryRepositoryDto, MaintenanceHistoryServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<MaintenanceHistoryRepositoryDto, MaintenanceHistoryServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(int id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<MaintenanceHistoryListServiceDto> GetAllAsync(MaintenanceHistoryQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<MaintenanceHistoryQueryServiceDto,MaintenanceHistoryQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<MaintenanceHistoryQueryServiceDto,MaintenanceHistoryQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<MaintenanceHistoryRepositoryDto,MaintenanceHistoryServiceDto>());
        var mapper2 = new Mapper(config2);
        return new MaintenanceHistoryListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<MaintenanceHistoryServiceDto>(x))
        };
    }

    public async Task<MaintenanceHistoryServiceDto> GetByIdAsync(int id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<MaintenanceHistoryRepositoryDto, MaintenanceHistoryServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<MaintenanceHistoryRepositoryDto, MaintenanceHistoryServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateMaintenanceHistoryServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateMaintenanceHistoryServiceDto, UpdateMaintenanceHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateMaintenanceHistoryServiceDto, UpdateMaintenanceHistoryRepositoryDto>(updateDto);
        await Task.WhenAll(
        updateDto.VehicleId.HasValue ? vehicleRepository.GetByIdAsync(updateDto.VehicleId.Value) : Task.CompletedTask,
		updateDto.MaintenanceTypeId.HasValue ? maintenanceTypeRepository.GetByIdAsync(updateDto.MaintenanceTypeId.Value) : Task.CompletedTask,
		updateDto.AutomechanicId.HasValue ? automechanicRepository.GetByIdAsync(updateDto.AutomechanicId.Value) : Task.CompletedTask);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}