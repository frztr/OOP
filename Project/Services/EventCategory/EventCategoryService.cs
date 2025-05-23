
using AutoMapper;
namespace Global;
using Microsoft.Extensions.Logging;
public class EventCategoryService(IEventCategoryRepository repository,

ILogger<EventCategoryService> logger) : IEventCategoryService
{
    public async Task<EventCategoryServiceDto> AddAsync(AddEventCategoryServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddEventCategoryServiceDto, AddEventCategoryRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddEventCategoryServiceDto, AddEventCategoryRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        );
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<EventCategoryRepositoryDto, EventCategoryServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<EventCategoryRepositoryDto, EventCategoryServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(short id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<EventCategoryListServiceDto> GetAllAsync(EventCategoryQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<EventCategoryQueryServiceDto,EventCategoryQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<EventCategoryQueryServiceDto,EventCategoryQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<EventCategoryRepositoryDto,EventCategoryServiceDto>());
        var mapper2 = new Mapper(config2);
        return new EventCategoryListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<EventCategoryServiceDto>(x))
        };
    }

    public async Task<EventCategoryServiceDto> GetByIdAsync(short id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<EventCategoryRepositoryDto, EventCategoryServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<EventCategoryRepositoryDto, EventCategoryServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateEventCategoryServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateEventCategoryServiceDto, UpdateEventCategoryRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateEventCategoryServiceDto, UpdateEventCategoryRepositoryDto>(updateDto);
        await Task.WhenAll(
        );
        await repository.UpdateAsync(updateRepositoryDto);
    }
}