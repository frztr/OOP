
namespace Global;
public interface ICityRepository
{
    public Task<CityListRepositoryDto> GetAllAsync(CityQueryRepositoryDto queryDto);

    public Task<CityRepositoryDto> GetByIdAsync(int id);

    public Task<CityRepositoryDto> AddAsync(AddCityRepositoryDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateCityRepositoryDto updateDto);
}