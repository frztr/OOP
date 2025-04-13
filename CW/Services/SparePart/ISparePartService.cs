
namespace Global;
public interface ISparePartService
{
    public Task<SparePartListServiceDto> GetAllAsync(SparePartQueryServiceDto queryDto);

    public Task<SparePartServiceDto> GetByIdAsync(int id);

    public Task<SparePartServiceDto> AddAsync(AddSparePartServiceDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateSparePartServiceDto updateDto);
}