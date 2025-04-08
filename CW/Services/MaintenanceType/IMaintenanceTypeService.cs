
namespace Global;
public interface IMaintenanceTypeService
    {
        public Task<MaintenanceTypeListServiceDto> GetAllAsync(short count = 50, short offset = 0);

        public Task<MaintenanceTypeServiceDto> GetByIdAsync(short id);

        public Task<MaintenanceTypeServiceDto> AddAsync(AddMaintenanceTypeServiceDto addDto);

        public Task DeleteAsync(short id);

        public Task UpdateAsync(UpdateMaintenanceTypeServiceDto updateDto);
    }