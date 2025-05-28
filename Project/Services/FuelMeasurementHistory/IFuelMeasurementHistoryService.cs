
namespace Global;
public interface IFuelMeasurementHistoryService
{
    public Task<FuelMeasurementHistoryListServiceDto> GetAllAsync(FuelMeasurementHistoryQueryServiceDto queryDto);

    public Task<FuelMeasurementHistoryServiceDto> GetByIdAsync(int id);

    public Task<FuelMeasurementHistoryServiceDto> AddAsync(AddFuelMeasurementHistoryServiceDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateFuelMeasurementHistoryServiceDto updateDto);
}