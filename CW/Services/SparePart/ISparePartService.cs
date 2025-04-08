
namespace Global;
public interface ISparePartService
    {
        public Task<SparePartListServiceDto> GetAllAsync(int count = 50, int offset = 0);

        public Task<SparePartServiceDto> GetByIdAsync(int id);

        public Task<SparePartServiceDto> AddAsync(AddSparePartServiceDto addDto);

        public Task DeleteAsync(int id);

        public Task UpdateAsync(UpdateSparePartServiceDto updateDto);
    }