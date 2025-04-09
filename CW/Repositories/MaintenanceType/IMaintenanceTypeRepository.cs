
        namespace Global;
        public interface IMaintenanceTypeRepository
{
    public Task<MaintenanceTypeListRepositoryDto> GetAllAsync(MaintenanceTypeQueryRepositoryDto queryDto);

    public Task<MaintenanceTypeRepositoryDto> GetByIdAsync(short id);

    public Task<MaintenanceTypeRepositoryDto> AddAsync(AddMaintenanceTypeRepositoryDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateMaintenanceTypeRepositoryDto updateDto);
}