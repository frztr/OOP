
using AutoMapper;
namespace Global;
using Microsoft.Extensions.Logging;
public class OilTypeService(IOilTypeRepository repository,
IFuelTypeRepository fuelTypeRepository,
ILogger<OilTypeService> logger) : IOilTypeService
{
    public async Task<OilTypeServiceDto> AddAsync(AddOilTypeServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddOilTypeServiceDto, AddOilTypeRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddOilTypeServiceDto, AddOilTypeRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        fuelTypeRepository.GetByIdAsync(addRepositoryDto.FuelTypeId));
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<OilTypeRepositoryDto, OilTypeServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<OilTypeRepositoryDto, OilTypeServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(short id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<OilTypeListServiceDto> GetAllAsync(OilTypeQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<OilTypeQueryServiceDto,OilTypeQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<OilTypeQueryServiceDto,OilTypeQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<OilTypeRepositoryDto,OilTypeServiceDto>());
        var mapper2 = new Mapper(config2);
        return new OilTypeListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<OilTypeServiceDto>(x))
        };
    }

    public async Task<OilTypeServiceDto> GetByIdAsync(short id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<OilTypeRepositoryDto, OilTypeServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<OilTypeRepositoryDto, OilTypeServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateOilTypeServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateOilTypeServiceDto, UpdateOilTypeRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateOilTypeServiceDto, UpdateOilTypeRepositoryDto>(updateDto);
        await Task.WhenAll(
        updateDto.FuelTypeId.HasValue ? fuelTypeRepository.GetByIdAsync(updateDto.FuelTypeId.Value) : Task.CompletedTask);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}