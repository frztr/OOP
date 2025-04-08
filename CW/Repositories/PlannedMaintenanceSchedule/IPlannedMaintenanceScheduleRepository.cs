
        namespace Global;
        public interface IPlannedMaintenanceScheduleRepository
{
    public Task<PlannedMaintenanceScheduleListRepositoryDto> GetAllAsync(int count = 50, int offset = 0);

    public Task<PlannedMaintenanceScheduleRepositoryDto> GetByIdAsync(int id);

    public Task<PlannedMaintenanceScheduleRepositoryDto> AddAsync(AddPlannedMaintenanceScheduleRepositoryDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdatePlannedMaintenanceScheduleRepositoryDto updateDto);
}