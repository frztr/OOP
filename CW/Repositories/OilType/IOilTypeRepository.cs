
namespace Global;
public interface IOilTypeRepository
{
    public Task<OilTypeListRepositoryDto> GetAllAsync(OilTypeQueryRepositoryDto queryDto);

    public Task<OilTypeRepositoryDto> GetByIdAsync(short id);

    public Task<OilTypeRepositoryDto> AddAsync(AddOilTypeRepositoryDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateOilTypeRepositoryDto updateDto);
}