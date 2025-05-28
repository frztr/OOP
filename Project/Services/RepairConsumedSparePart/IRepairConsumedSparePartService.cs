
namespace Global;
public interface IRepairConsumedSparePartService
{
    public Task<RepairConsumedSparePartListServiceDto> GetAllAsync(RepairConsumedSparePartQueryServiceDto queryDto);

    public Task<RepairConsumedSparePartServiceDto> GetByIdAsync(int id);

    public Task<RepairConsumedSparePartServiceDto> AddAsync(AddRepairConsumedSparePartServiceDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateRepairConsumedSparePartServiceDto updateDto);
}