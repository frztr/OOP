
namespace Global;
public interface IVehicleModelService
    {
        public Task<VehicleModelListServiceDto> GetAllAsync(int count = 50, int offset = 0);

        public Task<VehicleModelServiceDto> GetByIdAsync(int id);

        public Task<VehicleModelServiceDto> AddAsync(AddVehicleModelServiceDto addDto);

        public Task DeleteAsync(int id);

        public Task UpdateAsync(UpdateVehicleModelServiceDto updateDto);
    }