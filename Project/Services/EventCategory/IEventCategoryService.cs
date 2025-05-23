
namespace Global;
public interface IEventCategoryService
{
    public Task<EventCategoryListServiceDto> GetAllAsync(EventCategoryQueryServiceDto queryDto);

    public Task<EventCategoryServiceDto> GetByIdAsync(short id);

    public Task<EventCategoryServiceDto> AddAsync(AddEventCategoryServiceDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateEventCategoryServiceDto updateDto);
}