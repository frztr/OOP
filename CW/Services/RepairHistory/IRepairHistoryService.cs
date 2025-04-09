
namespace Global;
public interface IRepairHistoryService
    {
        public Task<RepairHistoryListServiceDto> GetAllAsync(RepairHistoryQueryServiceDto queryDto);

        public Task<RepairHistoryServiceDto> GetByIdAsync(int id);

        public Task<RepairHistoryServiceDto> AddAsync(AddRepairHistoryServiceDto addDto);

        public Task DeleteAsync(int id);

        public Task UpdateAsync(UpdateRepairHistoryServiceDto updateDto);
    }