
namespace Global;
public interface IDriverRepository
{
    public Task<DriverListRepositoryDto> GetAllAsync(DriverQueryRepositoryDto queryDto);

    public Task<DriverRepositoryDto> GetByIdAsync(short id);

    public Task<DriverRepositoryDto> AddAsync(AddDriverRepositoryDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateDriverRepositoryDto updateDto);
}