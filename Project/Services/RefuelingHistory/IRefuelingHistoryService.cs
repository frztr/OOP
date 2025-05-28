
namespace Global;
public interface IRefuelingHistoryService
{
    public Task<RefuelingHistoryListServiceDto> GetAllAsync(RefuelingHistoryQueryServiceDto queryDto);

    public Task<RefuelingHistoryServiceDto> GetByIdAsync(int id);

    public Task<RefuelingHistoryServiceDto> AddAsync(AddRefuelingHistoryServiceDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateRefuelingHistoryServiceDto updateDto);
}