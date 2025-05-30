
using AutoMapper;
namespace Global;
using Microsoft.Extensions.Logging;
public class CountryService(ICountryRepository repository,

ILogger<CountryService> logger) : ICountryService
{
    public async Task<CountryServiceDto> AddAsync(AddCountryServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddCountryServiceDto, AddCountryRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddCountryServiceDto, AddCountryRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        );
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<CountryRepositoryDto, CountryServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<CountryRepositoryDto, CountryServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(short id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<CountryListServiceDto> GetAllAsync(CountryQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<CountryQueryServiceDto,CountryQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<CountryQueryServiceDto,CountryQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<CountryRepositoryDto,CountryServiceDto>());
        var mapper2 = new Mapper(config2);
        return new CountryListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<CountryServiceDto>(x))
        };
    }

    public async Task<CountryServiceDto> GetByIdAsync(short id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<CountryRepositoryDto, CountryServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<CountryRepositoryDto, CountryServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateCountryServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateCountryServiceDto, UpdateCountryRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateCountryServiceDto, UpdateCountryRepositoryDto>(updateDto);
        await Task.WhenAll(
        );
        await repository.UpdateAsync(updateRepositoryDto);
    }
}