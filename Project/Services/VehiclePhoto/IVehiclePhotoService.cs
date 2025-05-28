
namespace Global;
public interface IVehiclePhotoService
{
    public Task<VehiclePhotoListServiceDto> GetAllAsync(VehiclePhotoQueryServiceDto queryDto);

    public Task<VehiclePhotoServiceDto> GetByIdAsync(int id);

    public Task<VehiclePhotoServiceDto> AddAsync(AddVehiclePhotoServiceDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateVehiclePhotoServiceDto updateDto);
}