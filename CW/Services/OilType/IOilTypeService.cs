
namespace Global;
public interface IOilTypeService
    {
        public Task<OilTypeListServiceDto> GetAllAsync(short count = 50, short offset = 0);

        public Task<OilTypeServiceDto> GetByIdAsync(short id);

        public Task<OilTypeServiceDto> AddAsync(AddOilTypeServiceDto addDto);

        public Task DeleteAsync(short id);

        public Task UpdateAsync(UpdateOilTypeServiceDto updateDto);
    }