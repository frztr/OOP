
using AutoMapper;
namespace Global;
using Microsoft.Extensions.Logging;
public class PlannedMaintenanceScheduleService(IPlannedMaintenanceScheduleRepository repository,
IMaintenanceTypeRepository maintenanceTypeRepository,
IVehicleRepository vehicleRepository,
ILogger<PlannedMaintenanceScheduleService> logger) : IPlannedMaintenanceScheduleService
{
    public async Task<PlannedMaintenanceScheduleServiceDto> AddAsync(AddPlannedMaintenanceScheduleServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddPlannedMaintenanceScheduleServiceDto, AddPlannedMaintenanceScheduleRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddPlannedMaintenanceScheduleServiceDto, AddPlannedMaintenanceScheduleRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        maintenanceTypeRepository.GetByIdAsync(addRepositoryDto.MaintenanceTypeId),
		vehicleRepository.GetByIdAsync(addRepositoryDto.VehicleId));
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<PlannedMaintenanceScheduleRepositoryDto, PlannedMaintenanceScheduleServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<PlannedMaintenanceScheduleRepositoryDto, PlannedMaintenanceScheduleServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(int id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<PlannedMaintenanceScheduleListServiceDto> GetAllAsync(PlannedMaintenanceScheduleQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<PlannedMaintenanceScheduleQueryServiceDto,PlannedMaintenanceScheduleQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<PlannedMaintenanceScheduleQueryServiceDto,PlannedMaintenanceScheduleQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<PlannedMaintenanceScheduleRepositoryDto,PlannedMaintenanceScheduleServiceDto>());
        var mapper2 = new Mapper(config2);
        return new PlannedMaintenanceScheduleListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<PlannedMaintenanceScheduleServiceDto>(x))
        };
    }

    public async Task<PlannedMaintenanceScheduleServiceDto> GetByIdAsync(int id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<PlannedMaintenanceScheduleRepositoryDto, PlannedMaintenanceScheduleServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<PlannedMaintenanceScheduleRepositoryDto, PlannedMaintenanceScheduleServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdatePlannedMaintenanceScheduleServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdatePlannedMaintenanceScheduleServiceDto, UpdatePlannedMaintenanceScheduleRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdatePlannedMaintenanceScheduleServiceDto, UpdatePlannedMaintenanceScheduleRepositoryDto>(updateDto);
        await Task.WhenAll(
        updateDto.MaintenanceTypeId.HasValue ? maintenanceTypeRepository.GetByIdAsync(updateDto.MaintenanceTypeId.Value) : Task.CompletedTask,
		updateDto.VehicleId.HasValue ? vehicleRepository.GetByIdAsync(updateDto.VehicleId.Value) : Task.CompletedTask);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}