
namespace Global;
public interface IManufacturerService
{
    public Task<ManufacturerListServiceDto> GetAllAsync(ManufacturerQueryServiceDto queryDto);

    public Task<ManufacturerServiceDto> GetByIdAsync(short id);

    public Task<ManufacturerServiceDto> AddAsync(AddManufacturerServiceDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateManufacturerServiceDto updateDto);
}