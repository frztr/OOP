
namespace Global;
public interface IPlannedMaintenanceScheduleService
    {
        public Task<PlannedMaintenanceScheduleListServiceDto> GetAllAsync(int count = 50, int offset = 0);

        public Task<PlannedMaintenanceScheduleServiceDto> GetByIdAsync(int id);

        public Task<PlannedMaintenanceScheduleServiceDto> AddAsync(AddPlannedMaintenanceScheduleServiceDto addDto);

        public Task DeleteAsync(int id);

        public Task UpdateAsync(UpdatePlannedMaintenanceScheduleServiceDto updateDto);
    }