
namespace Global;
public interface IEventService
{
    public Task<EventListServiceDto> GetAllAsync(EventQueryServiceDto queryDto);

    public Task<EventServiceDto> GetByIdAsync(int id);

    public Task<EventServiceDto> AddAsync(AddEventServiceDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateEventServiceDto updateDto);
}