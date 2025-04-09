
using AutoMapper;
namespace Global;
public class FuelMeasurementHistoryService(IFuelMeasurementHistoryRepository repository, ILogger<FuelMeasurementHistoryService> logger) : IFuelMeasurementHistoryService
{
    public async Task<FuelMeasurementHistoryServiceDto> AddAsync(AddFuelMeasurementHistoryServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddFuelMeasurementHistoryServiceDto, AddFuelMeasurementHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddFuelMeasurementHistoryServiceDto, AddFuelMeasurementHistoryRepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<FuelMeasurementHistoryRepositoryDto, FuelMeasurementHistoryServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<FuelMeasurementHistoryRepositoryDto, FuelMeasurementHistoryServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(int id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<FuelMeasurementHistoryListServiceDto> GetAllAsync(FuelMeasurementHistoryQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<FuelMeasurementHistoryQueryServiceDto,FuelMeasurementHistoryQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<FuelMeasurementHistoryQueryServiceDto,FuelMeasurementHistoryQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<FuelMeasurementHistoryRepositoryDto,FuelMeasurementHistoryServiceDto>());
        var mapper2 = new Mapper(config2);
        return new FuelMeasurementHistoryListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<FuelMeasurementHistoryServiceDto>(x))
        };
    }

    public async Task<FuelMeasurementHistoryServiceDto> GetByIdAsync(int id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<FuelMeasurementHistoryRepositoryDto, FuelMeasurementHistoryServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<FuelMeasurementHistoryRepositoryDto, FuelMeasurementHistoryServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateFuelMeasurementHistoryServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateFuelMeasurementHistoryServiceDto, UpdateFuelMeasurementHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateFuelMeasurementHistoryServiceDto, UpdateFuelMeasurementHistoryRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}