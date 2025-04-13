
namespace Global;
public interface IVehicleService
{
    public Task<VehicleListServiceDto> GetAllAsync(VehicleQueryServiceDto queryDto);

    public Task<VehicleServiceDto> GetByIdAsync(int id);

    public Task<VehicleServiceDto> AddAsync(AddVehicleServiceDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateVehicleServiceDto updateDto);
}