
        namespace Global;
        public interface IDriverRepository
{
    public Task<DriverListRepositoryDto> GetAllAsync(short count = 50, short offset = 0);

    public Task<DriverRepositoryDto> GetByIdAsync(short id);

    public Task<DriverRepositoryDto> AddAsync(AddDriverRepositoryDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateDriverRepositoryDto updateDto);
}