
using AutoMapper;
namespace Global;
public class AutomechanicService(IAutomechanicRepository repository,

ILogger<AutomechanicService> logger) : IAutomechanicService
{
    public async Task<AutomechanicServiceDto> AddAsync(AddAutomechanicServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddAutomechanicServiceDto, AddAutomechanicRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddAutomechanicServiceDto, AddAutomechanicRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        );
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<AutomechanicRepositoryDto, AutomechanicServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<AutomechanicRepositoryDto, AutomechanicServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(short id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<AutomechanicListServiceDto> GetAllAsync(AutomechanicQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AutomechanicQueryServiceDto,AutomechanicQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<AutomechanicQueryServiceDto,AutomechanicQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<AutomechanicRepositoryDto,AutomechanicServiceDto>());
        var mapper2 = new Mapper(config2);
        return new AutomechanicListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<AutomechanicServiceDto>(x))
        };
    }

    public async Task<AutomechanicServiceDto> GetByIdAsync(short id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AutomechanicRepositoryDto, AutomechanicServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<AutomechanicRepositoryDto, AutomechanicServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateAutomechanicServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateAutomechanicServiceDto, UpdateAutomechanicRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateAutomechanicServiceDto, UpdateAutomechanicRepositoryDto>(updateDto);
        await Task.WhenAll(
        );
        await repository.UpdateAsync(updateRepositoryDto);
    }
}