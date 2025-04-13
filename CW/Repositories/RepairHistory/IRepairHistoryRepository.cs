
namespace Global;
public interface IRepairHistoryRepository
{
    public Task<RepairHistoryListRepositoryDto> GetAllAsync(RepairHistoryQueryRepositoryDto queryDto);

    public Task<RepairHistoryRepositoryDto> GetByIdAsync(int id);

    public Task<RepairHistoryRepositoryDto> AddAsync(AddRepairHistoryRepositoryDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateRepairHistoryRepositoryDto updateDto);
}