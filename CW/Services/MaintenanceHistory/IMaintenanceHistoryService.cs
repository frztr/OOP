
namespace Global;
public interface IMaintenanceHistoryService
{
    public Task<MaintenanceHistoryListServiceDto> GetAllAsync(MaintenanceHistoryQueryServiceDto queryDto);

    public Task<MaintenanceHistoryServiceDto> GetByIdAsync(int id);

    public Task<MaintenanceHistoryServiceDto> AddAsync(AddMaintenanceHistoryServiceDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateMaintenanceHistoryServiceDto updateDto);
}