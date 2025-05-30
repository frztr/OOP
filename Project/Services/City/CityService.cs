
using AutoMapper;
namespace Global;
using Microsoft.Extensions.Logging;
public class CityService(ICityRepository repository,
ICountryRepository countryRepository,
ILogger<CityService> logger) : ICityService
{
    public async Task<CityServiceDto> AddAsync(AddCityServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddCityServiceDto, AddCityRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddCityServiceDto, AddCityRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        countryRepository.GetByIdAsync(addRepositoryDto.CountryId));
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<CityRepositoryDto, CityServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<CityRepositoryDto, CityServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(int id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<CityListServiceDto> GetAllAsync(CityQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<CityQueryServiceDto,CityQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<CityQueryServiceDto,CityQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<CityRepositoryDto,CityServiceDto>());
        var mapper2 = new Mapper(config2);
        return new CityListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<CityServiceDto>(x))
        };
    }

    public async Task<CityServiceDto> GetByIdAsync(int id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<CityRepositoryDto, CityServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<CityRepositoryDto, CityServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateCityServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateCityServiceDto, UpdateCityRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateCityServiceDto, UpdateCityRepositoryDto>(updateDto);
        await Task.WhenAll(
        updateDto.CountryId.HasValue ? countryRepository.GetByIdAsync(updateDto.CountryId.Value) : Task.CompletedTask);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}