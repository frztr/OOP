
        namespace Global;
        public interface IFuelMeasurementHistoryRepository
{
    public Task<FuelMeasurementHistoryListRepositoryDto> GetAllAsync(FuelMeasurementHistoryQueryRepositoryDto queryDto);

    public Task<FuelMeasurementHistoryRepositoryDto> GetByIdAsync(int id);

    public Task<FuelMeasurementHistoryRepositoryDto> AddAsync(AddFuelMeasurementHistoryRepositoryDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateFuelMeasurementHistoryRepositoryDto updateDto);
}