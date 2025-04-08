
namespace Global;
public interface IMaintenanceHistoryService
    {
        public Task<MaintenanceHistoryListServiceDto> GetAllAsync(int count = 50, int offset = 0);

        public Task<MaintenanceHistoryServiceDto> GetByIdAsync(int id);

        public Task<MaintenanceHistoryServiceDto> AddAsync(AddMaintenanceHistoryServiceDto addDto);

        public Task DeleteAsync(int id);

        public Task UpdateAsync(UpdateMaintenanceHistoryServiceDto updateDto);
    }