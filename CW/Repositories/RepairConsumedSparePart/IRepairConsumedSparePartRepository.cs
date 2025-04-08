
        namespace Global;
        public interface IRepairConsumedSparePartRepository
{
    public Task<RepairConsumedSparePartListRepositoryDto> GetAllAsync(int count = 50, int offset = 0);

    public Task<RepairConsumedSparePartRepositoryDto> GetByIdAsync(int id);

    public Task<RepairConsumedSparePartRepositoryDto> AddAsync(AddRepairConsumedSparePartRepositoryDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateRepairConsumedSparePartRepositoryDto updateDto);
}