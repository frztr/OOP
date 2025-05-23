
using AutoMapper;
namespace Global;
using Microsoft.Extensions.Logging;
public class LocationService(ILocationRepository repository,

ILogger<LocationService> logger) : ILocationService
{
    public async Task<LocationServiceDto> AddAsync(AddLocationServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddLocationServiceDto, AddLocationRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddLocationServiceDto, AddLocationRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        );
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<LocationRepositoryDto, LocationServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<LocationRepositoryDto, LocationServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(short id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<LocationListServiceDto> GetAllAsync(LocationQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<LocationQueryServiceDto,LocationQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<LocationQueryServiceDto,LocationQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<LocationRepositoryDto,LocationServiceDto>());
        var mapper2 = new Mapper(config2);
        return new LocationListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<LocationServiceDto>(x))
        };
    }

    public async Task<LocationServiceDto> GetByIdAsync(short id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<LocationRepositoryDto, LocationServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<LocationRepositoryDto, LocationServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateLocationServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateLocationServiceDto, UpdateLocationRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateLocationServiceDto, UpdateLocationRepositoryDto>(updateDto);
        await Task.WhenAll(
        );
        await repository.UpdateAsync(updateRepositoryDto);
    }
}