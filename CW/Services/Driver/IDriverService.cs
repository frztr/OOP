
namespace Global;
public interface IDriverService
    {
        public Task<DriverListServiceDto> GetAllAsync(DriverQueryServiceDto queryDto);

        public Task<DriverServiceDto> GetByIdAsync(short id);

        public Task<DriverServiceDto> AddAsync(AddDriverServiceDto addDto);

        public Task DeleteAsync(short id);

        public Task UpdateAsync(UpdateDriverServiceDto updateDto);
    }