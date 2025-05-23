
namespace Global;
public interface ILocationService
{
    public Task<LocationListServiceDto> GetAllAsync(LocationQueryServiceDto queryDto);

    public Task<LocationServiceDto> GetByIdAsync(short id);

    public Task<LocationServiceDto> AddAsync(AddLocationServiceDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateLocationServiceDto updateDto);
}