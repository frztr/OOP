
namespace Global;
public interface IRefuelingHistoryRepository
{
    public Task<RefuelingHistoryListRepositoryDto> GetAllAsync(RefuelingHistoryQueryRepositoryDto queryDto);

    public Task<RefuelingHistoryRepositoryDto> GetByIdAsync(int id);

    public Task<RefuelingHistoryRepositoryDto> AddAsync(AddRefuelingHistoryRepositoryDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateRefuelingHistoryRepositoryDto updateDto);
}