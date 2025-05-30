
namespace Global;
public interface ICityService
{
    public Task<CityListServiceDto> GetAllAsync(CityQueryServiceDto queryDto);

    public Task<CityServiceDto> GetByIdAsync(int id);

    public Task<CityServiceDto> AddAsync(AddCityServiceDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateCityServiceDto updateDto);
}