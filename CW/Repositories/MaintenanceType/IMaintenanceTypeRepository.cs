
        namespace Global;
        public interface IMaintenanceTypeRepository
{
    public Task<MaintenanceTypeListRepositoryDto> GetAllAsync(short count = 50, short offset = 0);

    public Task<MaintenanceTypeRepositoryDto> GetByIdAsync(short id);

    public Task<MaintenanceTypeRepositoryDto> AddAsync(AddMaintenanceTypeRepositoryDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateMaintenanceTypeRepositoryDto updateDto);
}