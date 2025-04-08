
namespace Global;
public interface IVehicleService
    {
        public Task<VehicleListServiceDto> GetAllAsync(int count = 50, int offset = 0);

        public Task<VehicleServiceDto> GetByIdAsync(int id);

        public Task<VehicleServiceDto> AddAsync(AddVehicleServiceDto addDto);

        public Task DeleteAsync(int id);

        public Task UpdateAsync(UpdateVehicleServiceDto updateDto);
    }