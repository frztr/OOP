
        namespace Global;
        public interface IRefuelingHistoryRepository
{
    public Task<RefuelingHistoryListRepositoryDto> GetAllAsync(int count = 50, int offset = 0);

    public Task<RefuelingHistoryRepositoryDto> GetByIdAsync(int id);

    public Task<RefuelingHistoryRepositoryDto> AddAsync(AddRefuelingHistoryRepositoryDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateRefuelingHistoryRepositoryDto updateDto);
}