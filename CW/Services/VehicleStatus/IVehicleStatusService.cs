
namespace Global;
public interface IVehicleStatusService
    {
        public Task<VehicleStatusListServiceDto> GetAllAsync(short count = 50, short offset = 0);

        public Task<VehicleStatusServiceDto> GetByIdAsync(short id);

        public Task<VehicleStatusServiceDto> AddAsync(AddVehicleStatusServiceDto addDto);

        public Task DeleteAsync(short id);

        public Task UpdateAsync(UpdateVehicleStatusServiceDto updateDto);
    }