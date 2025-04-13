
namespace Global;
public interface IVehiclePhotoRepository
{
    public Task<VehiclePhotoListRepositoryDto> GetAllAsync(VehiclePhotoQueryRepositoryDto queryDto);

    public Task<VehiclePhotoRepositoryDto> GetByIdAsync(int id);

    public Task<VehiclePhotoRepositoryDto> AddAsync(AddVehiclePhotoRepositoryDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateVehiclePhotoRepositoryDto updateDto);
}