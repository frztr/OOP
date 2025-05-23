
using AutoMapper;
namespace Global;
using Microsoft.Extensions.Logging;
public class EventService(IEventRepository repository,
ILocationRepository locationRepository,
IUserRepository userRepository,
IEventCategoryRepository eventCategoryRepository,
ILogger<EventService> logger) : IEventService
{
    public async Task<EventServiceDto> AddAsync(AddEventServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddEventServiceDto, AddEventRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddEventServiceDto, AddEventRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        locationRepository.GetByIdAsync(addRepositoryDto.LocationId),
		userRepository.GetByIdAsync(addRepositoryDto.CreatedBy),
		eventCategoryRepository.GetByIdAsync(addRepositoryDto.EventCategoryId));
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<EventRepositoryDto, EventServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<EventRepositoryDto, EventServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(int id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<EventListServiceDto> GetAllAsync(EventQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<EventQueryServiceDto,EventQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<EventQueryServiceDto,EventQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<EventRepositoryDto,EventServiceDto>());
        var mapper2 = new Mapper(config2);
        return new EventListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<EventServiceDto>(x))
        };
    }

    public async Task<EventServiceDto> GetByIdAsync(int id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<EventRepositoryDto, EventServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<EventRepositoryDto, EventServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateEventServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateEventServiceDto, UpdateEventRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateEventServiceDto, UpdateEventRepositoryDto>(updateDto);
        await Task.WhenAll(
        updateDto.LocationId.HasValue ? locationRepository.GetByIdAsync(updateDto.LocationId.Value) : Task.CompletedTask,
		updateDto.CreatedBy.HasValue ? userRepository.GetByIdAsync(updateDto.CreatedBy.Value) : Task.CompletedTask,
		updateDto.EventCategoryId.HasValue ? eventCategoryRepository.GetByIdAsync(updateDto.EventCategoryId.Value) : Task.CompletedTask);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}