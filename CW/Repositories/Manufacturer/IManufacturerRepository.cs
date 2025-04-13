
namespace Global;
public interface IManufacturerRepository
{
    public Task<ManufacturerListRepositoryDto> GetAllAsync(ManufacturerQueryRepositoryDto queryDto);

    public Task<ManufacturerRepositoryDto> GetByIdAsync(short id);

    public Task<ManufacturerRepositoryDto> AddAsync(AddManufacturerRepositoryDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateManufacturerRepositoryDto updateDto);
}