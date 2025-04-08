
        namespace Global;
        public interface IMaintenanceHistoryRepository
{
    public Task<MaintenanceHistoryListRepositoryDto> GetAllAsync(int count = 50, int offset = 0);

    public Task<MaintenanceHistoryRepositoryDto> GetByIdAsync(int id);

    public Task<MaintenanceHistoryRepositoryDto> AddAsync(AddMaintenanceHistoryRepositoryDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateMaintenanceHistoryRepositoryDto updateDto);
}