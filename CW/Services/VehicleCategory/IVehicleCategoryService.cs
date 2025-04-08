
namespace Global;
public interface IVehicleCategoryService
    {
        public Task<VehicleCategoryListServiceDto> GetAllAsync(short count = 50, short offset = 0);

        public Task<VehicleCategoryServiceDto> GetByIdAsync(short id);

        public Task<VehicleCategoryServiceDto> AddAsync(AddVehicleCategoryServiceDto addDto);

        public Task DeleteAsync(short id);

        public Task UpdateAsync(UpdateVehicleCategoryServiceDto updateDto);
    }