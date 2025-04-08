
namespace Global;
public interface IVehicleDocumentService
    {
        public Task<VehicleDocumentListServiceDto> GetAllAsync(int count = 50, int offset = 0);

        public Task<VehicleDocumentServiceDto> GetByIdAsync(int id);

        public Task<VehicleDocumentServiceDto> AddAsync(AddVehicleDocumentServiceDto addDto);

        public Task DeleteAsync(int id);

        public Task UpdateAsync(UpdateVehicleDocumentServiceDto updateDto);
    }