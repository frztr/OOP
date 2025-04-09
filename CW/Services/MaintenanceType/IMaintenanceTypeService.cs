
namespace Global;
public interface IMaintenanceTypeService
    {
        public Task<MaintenanceTypeListServiceDto> GetAllAsync(MaintenanceTypeQueryServiceDto queryDto);

        public Task<MaintenanceTypeServiceDto> GetByIdAsync(short id);

        public Task<MaintenanceTypeServiceDto> AddAsync(AddMaintenanceTypeServiceDto addDto);

        public Task DeleteAsync(short id);

        public Task UpdateAsync(UpdateMaintenanceTypeServiceDto updateDto);
    }