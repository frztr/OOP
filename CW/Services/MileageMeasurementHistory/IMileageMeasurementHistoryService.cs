
namespace Global;
public interface IMileageMeasurementHistoryService
    {
        public Task<MileageMeasurementHistoryListServiceDto> GetAllAsync(MileageMeasurementHistoryQueryServiceDto queryDto);

        public Task<MileageMeasurementHistoryServiceDto> GetByIdAsync(int id);

        public Task<MileageMeasurementHistoryServiceDto> AddAsync(AddMileageMeasurementHistoryServiceDto addDto);

        public Task DeleteAsync(int id);

        public Task UpdateAsync(UpdateMileageMeasurementHistoryServiceDto updateDto);
    }