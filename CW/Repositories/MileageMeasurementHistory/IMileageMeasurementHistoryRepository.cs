
        namespace Global;
        public interface IMileageMeasurementHistoryRepository
{
    public Task<MileageMeasurementHistoryListRepositoryDto> GetAllAsync(int count = 50, int offset = 0);

    public Task<MileageMeasurementHistoryRepositoryDto> GetByIdAsync(int id);

    public Task<MileageMeasurementHistoryRepositoryDto> AddAsync(AddMileageMeasurementHistoryRepositoryDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateMileageMeasurementHistoryRepositoryDto updateDto);
}