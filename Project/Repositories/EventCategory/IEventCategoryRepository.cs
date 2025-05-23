
namespace Global;
public interface IEventCategoryRepository
{
    public Task<EventCategoryListRepositoryDto> GetAllAsync(EventCategoryQueryRepositoryDto queryDto);

    public Task<EventCategoryRepositoryDto> GetByIdAsync(short id);

    public Task<EventCategoryRepositoryDto> AddAsync(AddEventCategoryRepositoryDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateEventCategoryRepositoryDto updateDto);
}