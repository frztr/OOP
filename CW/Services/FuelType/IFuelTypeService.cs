
namespace Global;
public interface IFuelTypeService
    {
        public Task<FuelTypeListServiceDto> GetAllAsync(short count = 50, short offset = 0);

        public Task<FuelTypeServiceDto> GetByIdAsync(short id);

        public Task<FuelTypeServiceDto> AddAsync(AddFuelTypeServiceDto addDto);

        public Task DeleteAsync(short id);

        public Task UpdateAsync(UpdateFuelTypeServiceDto updateDto);
    }