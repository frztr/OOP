
namespace Global;
public interface IVehicleDocumentService
{
    public Task<VehicleDocumentListServiceDto> GetAllAsync(VehicleDocumentQueryServiceDto queryDto);

    public Task<VehicleDocumentServiceDto> GetByIdAsync(int id);

    public Task<VehicleDocumentServiceDto> AddAsync(AddVehicleDocumentServiceDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateVehicleDocumentServiceDto updateDto);
}