
namespace Global;
public interface ICountryRepository
{
    public Task<CountryListRepositoryDto> GetAllAsync(CountryQueryRepositoryDto queryDto);

    public Task<CountryRepositoryDto> GetByIdAsync(short id);

    public Task<CountryRepositoryDto> AddAsync(AddCountryRepositoryDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateCountryRepositoryDto updateDto);
}