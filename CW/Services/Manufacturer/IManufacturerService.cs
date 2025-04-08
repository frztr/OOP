
namespace Global;
public interface IManufacturerService
    {
        public Task<ManufacturerListServiceDto> GetAllAsync(short count = 50, short offset = 0);

        public Task<ManufacturerServiceDto> GetByIdAsync(short id);

        public Task<ManufacturerServiceDto> AddAsync(AddManufacturerServiceDto addDto);

        public Task DeleteAsync(short id);

        public Task UpdateAsync(UpdateManufacturerServiceDto updateDto);
    }