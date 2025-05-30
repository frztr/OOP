
namespace Global;
public interface ICountryService
{
    public Task<CountryListServiceDto> GetAllAsync(CountryQueryServiceDto queryDto);

    public Task<CountryServiceDto> GetByIdAsync(short id);

    public Task<CountryServiceDto> AddAsync(AddCountryServiceDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateCountryServiceDto updateDto);
}