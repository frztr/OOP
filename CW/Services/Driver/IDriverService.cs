
namespace Global;
public interface IDriverService
    {
        public Task<DriverListServiceDto> GetAllAsync(short count = 50, short offset = 0);

        public Task<DriverServiceDto> GetByIdAsync(short id);

        public Task<DriverServiceDto> AddAsync(AddDriverServiceDto addDto);

        public Task DeleteAsync(short id);

        public Task UpdateAsync(UpdateDriverServiceDto updateDto);
    }