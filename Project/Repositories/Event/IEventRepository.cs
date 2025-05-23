
namespace Global;
public interface IEventRepository
{
    public Task<EventListRepositoryDto> GetAllAsync(EventQueryRepositoryDto queryDto);

    public Task<EventRepositoryDto> GetByIdAsync(int id);

    public Task<EventRepositoryDto> AddAsync(AddEventRepositoryDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateEventRepositoryDto updateDto);
}