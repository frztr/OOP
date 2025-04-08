
        namespace Global;
        public interface IRepairHistoryRepository
{
    public Task<RepairHistoryListRepositoryDto> GetAllAsync(int count = 50, int offset = 0);

    public Task<RepairHistoryRepositoryDto> GetByIdAsync(int id);

    public Task<RepairHistoryRepositoryDto> AddAsync(AddRepairHistoryRepositoryDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateRepairHistoryRepositoryDto updateDto);
}