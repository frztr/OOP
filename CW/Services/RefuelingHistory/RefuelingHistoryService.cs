
using AutoMapper;
namespace Global;
public class RefuelingHistoryService(IRefuelingHistoryRepository repository,
IOilTypeRepository oilTypeRepository,
IVehicleRepository vehicleRepository,
IDriverRepository driverRepository,
ILogger<RefuelingHistoryService> logger) : IRefuelingHistoryService
{
    public async Task<RefuelingHistoryServiceDto> AddAsync(AddRefuelingHistoryServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddRefuelingHistoryServiceDto, AddRefuelingHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddRefuelingHistoryServiceDto, AddRefuelingHistoryRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        oilTypeRepository.GetByIdAsync(addRepositoryDto.OilTypeId),
		vehicleRepository.GetByIdAsync(addRepositoryDto.VehicleId),
		driverRepository.GetByIdAsync(addRepositoryDto.DriverId));
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<RefuelingHistoryRepositoryDto, RefuelingHistoryServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<RefuelingHistoryRepositoryDto, RefuelingHistoryServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(int id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<RefuelingHistoryListServiceDto> GetAllAsync(RefuelingHistoryQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<RefuelingHistoryQueryServiceDto,RefuelingHistoryQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<RefuelingHistoryQueryServiceDto,RefuelingHistoryQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<RefuelingHistoryRepositoryDto,RefuelingHistoryServiceDto>());
        var mapper2 = new Mapper(config2);
        return new RefuelingHistoryListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<RefuelingHistoryServiceDto>(x))
        };
    }

    public async Task<RefuelingHistoryServiceDto> GetByIdAsync(int id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<RefuelingHistoryRepositoryDto, RefuelingHistoryServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<RefuelingHistoryRepositoryDto, RefuelingHistoryServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateRefuelingHistoryServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateRefuelingHistoryServiceDto, UpdateRefuelingHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateRefuelingHistoryServiceDto, UpdateRefuelingHistoryRepositoryDto>(updateDto);
        await Task.WhenAll(
        updateDto.OilTypeId.HasValue ? oilTypeRepository.GetByIdAsync(updateDto.OilTypeId.Value) : Task.CompletedTask,
		updateDto.VehicleId.HasValue ? vehicleRepository.GetByIdAsync(updateDto.VehicleId.Value) : Task.CompletedTask,
		updateDto.DriverId.HasValue ? driverRepository.GetByIdAsync(updateDto.DriverId.Value) : Task.CompletedTask);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}