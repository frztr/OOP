
namespace Global;
public interface IFuelMeasurementHistoryService
    {
        public Task<FuelMeasurementHistoryListServiceDto> GetAllAsync(int count = 50, int offset = 0);

        public Task<FuelMeasurementHistoryServiceDto> GetByIdAsync(int id);

        public Task<FuelMeasurementHistoryServiceDto> AddAsync(AddFuelMeasurementHistoryServiceDto addDto);

        public Task DeleteAsync(int id);

        public Task UpdateAsync(UpdateFuelMeasurementHistoryServiceDto updateDto);
    }