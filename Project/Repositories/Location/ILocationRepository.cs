
namespace Global;
public interface ILocationRepository
{
    public Task<LocationListRepositoryDto> GetAllAsync(LocationQueryRepositoryDto queryDto);

    public Task<LocationRepositoryDto> GetByIdAsync(short id);

    public Task<LocationRepositoryDto> AddAsync(AddLocationRepositoryDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateLocationRepositoryDto updateDto);
}