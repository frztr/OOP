
namespace Global;
public interface IPlannedMaintenanceScheduleService
    {
        public Task<PlannedMaintenanceScheduleListServiceDto> GetAllAsync(PlannedMaintenanceScheduleQueryServiceDto queryDto);

        public Task<PlannedMaintenanceScheduleServiceDto> GetByIdAsync(int id);

        public Task<PlannedMaintenanceScheduleServiceDto> AddAsync(AddPlannedMaintenanceScheduleServiceDto addDto);

        public Task DeleteAsync(int id);

        public Task UpdateAsync(UpdatePlannedMaintenanceScheduleServiceDto updateDto);
    }