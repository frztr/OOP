
namespace Global;
public interface IRefuelingHistoryService
    {
        public Task<RefuelingHistoryListServiceDto> GetAllAsync(int count = 50, int offset = 0);

        public Task<RefuelingHistoryServiceDto> GetByIdAsync(int id);

        public Task<RefuelingHistoryServiceDto> AddAsync(AddRefuelingHistoryServiceDto addDto);

        public Task DeleteAsync(int id);

        public Task UpdateAsync(UpdateRefuelingHistoryServiceDto updateDto);
    }