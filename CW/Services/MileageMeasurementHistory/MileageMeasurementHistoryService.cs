
using AutoMapper;
namespace Global;
using Microsoft.Extensions.Logging;
public class MileageMeasurementHistoryService(IMileageMeasurementHistoryRepository repository,
IVehicleRepository vehicleRepository,
ILogger<MileageMeasurementHistoryService> logger) : IMileageMeasurementHistoryService
{
    public async Task<MileageMeasurementHistoryServiceDto> AddAsync(AddMileageMeasurementHistoryServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddMileageMeasurementHistoryServiceDto, AddMileageMeasurementHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddMileageMeasurementHistoryServiceDto, AddMileageMeasurementHistoryRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        vehicleRepository.GetByIdAsync(addRepositoryDto.VehicleId));
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<MileageMeasurementHistoryRepositoryDto, MileageMeasurementHistoryServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<MileageMeasurementHistoryRepositoryDto, MileageMeasurementHistoryServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(int id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<MileageMeasurementHistoryListServiceDto> GetAllAsync(MileageMeasurementHistoryQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<MileageMeasurementHistoryQueryServiceDto,MileageMeasurementHistoryQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<MileageMeasurementHistoryQueryServiceDto,MileageMeasurementHistoryQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<MileageMeasurementHistoryRepositoryDto,MileageMeasurementHistoryServiceDto>());
        var mapper2 = new Mapper(config2);
        return new MileageMeasurementHistoryListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<MileageMeasurementHistoryServiceDto>(x))
        };
    }

    public async Task<MileageMeasurementHistoryServiceDto> GetByIdAsync(int id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<MileageMeasurementHistoryRepositoryDto, MileageMeasurementHistoryServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<MileageMeasurementHistoryRepositoryDto, MileageMeasurementHistoryServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateMileageMeasurementHistoryServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateMileageMeasurementHistoryServiceDto, UpdateMileageMeasurementHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateMileageMeasurementHistoryServiceDto, UpdateMileageMeasurementHistoryRepositoryDto>(updateDto);
        await Task.WhenAll(
        updateDto.VehicleId.HasValue ? vehicleRepository.GetByIdAsync(updateDto.VehicleId.Value) : Task.CompletedTask);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}