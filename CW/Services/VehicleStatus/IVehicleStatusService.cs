
namespace Global;
public interface IVehicleStatusService
    {
        public Task<VehicleStatusListServiceDto> GetAllAsync(VehicleStatusQueryServiceDto queryDto);

        public Task<VehicleStatusServiceDto> GetByIdAsync(short id);

        public Task<VehicleStatusServiceDto> AddAsync(AddVehicleStatusServiceDto addDto);

        public Task DeleteAsync(short id);

        public Task UpdateAsync(UpdateVehicleStatusServiceDto updateDto);
    }