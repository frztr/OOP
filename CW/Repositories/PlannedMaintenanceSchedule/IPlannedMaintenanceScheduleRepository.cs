
        namespace Global;
        public interface IPlannedMaintenanceScheduleRepository
{
    public Task<PlannedMaintenanceScheduleListRepositoryDto> GetAllAsync(PlannedMaintenanceScheduleQueryRepositoryDto queryDto);

    public Task<PlannedMaintenanceScheduleRepositoryDto> GetByIdAsync(int id);

    public Task<PlannedMaintenanceScheduleRepositoryDto> AddAsync(AddPlannedMaintenanceScheduleRepositoryDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdatePlannedMaintenanceScheduleRepositoryDto updateDto);
}