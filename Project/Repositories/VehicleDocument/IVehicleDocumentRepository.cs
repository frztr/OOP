
namespace Global;
public interface IVehicleDocumentRepository
{
    public Task<VehicleDocumentListRepositoryDto> GetAllAsync(VehicleDocumentQueryRepositoryDto queryDto);

    public Task<VehicleDocumentRepositoryDto> GetByIdAsync(int id);

    public Task<VehicleDocumentRepositoryDto> AddAsync(AddVehicleDocumentRepositoryDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateVehicleDocumentRepositoryDto updateDto);
}