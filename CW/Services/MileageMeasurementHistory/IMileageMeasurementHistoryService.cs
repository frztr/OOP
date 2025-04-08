
namespace Global;
public interface IMileageMeasurementHistoryService
    {
        public Task<MileageMeasurementHistoryListServiceDto> GetAllAsync(int count = 50, int offset = 0);

        public Task<MileageMeasurementHistoryServiceDto> GetByIdAsync(int id);

        public Task<MileageMeasurementHistoryServiceDto> AddAsync(AddMileageMeasurementHistoryServiceDto addDto);

        public Task DeleteAsync(int id);

        public Task UpdateAsync(UpdateMileageMeasurementHistoryServiceDto updateDto);
    }