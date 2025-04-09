
        namespace Global;
        public interface IRepairConsumedSparePartRepository
{
    public Task<RepairConsumedSparePartListRepositoryDto> GetAllAsync(RepairConsumedSparePartQueryRepositoryDto queryDto);

    public Task<RepairConsumedSparePartRepositoryDto> GetByIdAsync(int id);

    public Task<RepairConsumedSparePartRepositoryDto> AddAsync(AddRepairConsumedSparePartRepositoryDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateRepairConsumedSparePartRepositoryDto updateDto);
}