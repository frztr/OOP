
        namespace Global;
        public interface IFuelMeasurementHistoryRepository
{
    public Task<FuelMeasurementHistoryListRepositoryDto> GetAllAsync(int count = 50, int offset = 0);

    public Task<FuelMeasurementHistoryRepositoryDto> GetByIdAsync(int id);

    public Task<FuelMeasurementHistoryRepositoryDto> AddAsync(AddFuelMeasurementHistoryRepositoryDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateFuelMeasurementHistoryRepositoryDto updateDto);
}