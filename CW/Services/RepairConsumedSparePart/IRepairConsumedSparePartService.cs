
namespace Global;
public interface IRepairConsumedSparePartService
    {
        public Task<RepairConsumedSparePartListServiceDto> GetAllAsync(int count = 50, int offset = 0);

        public Task<RepairConsumedSparePartServiceDto> GetByIdAsync(int id);

        public Task<RepairConsumedSparePartServiceDto> AddAsync(AddRepairConsumedSparePartServiceDto addDto);

        public Task DeleteAsync(int id);

        public Task UpdateAsync(UpdateRepairConsumedSparePartServiceDto updateDto);
    }