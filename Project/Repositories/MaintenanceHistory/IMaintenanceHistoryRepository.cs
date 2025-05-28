
namespace Global;
public interface IMaintenanceHistoryRepository
{
    public Task<MaintenanceHistoryListRepositoryDto> GetAllAsync(MaintenanceHistoryQueryRepositoryDto queryDto);

    public Task<MaintenanceHistoryRepositoryDto> GetByIdAsync(int id);

    public Task<MaintenanceHistoryRepositoryDto> AddAsync(AddMaintenanceHistoryRepositoryDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateMaintenanceHistoryRepositoryDto updateDto);
}