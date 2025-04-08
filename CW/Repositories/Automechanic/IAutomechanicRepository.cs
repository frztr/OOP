
        namespace Global;
        public interface IAutomechanicRepository
{
    public Task<AutomechanicListRepositoryDto> GetAllAsync(short count = 50, short offset = 0);

    public Task<AutomechanicRepositoryDto> GetByIdAsync(short id);

    public Task<AutomechanicRepositoryDto> AddAsync(AddAutomechanicRepositoryDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateAutomechanicRepositoryDto updateDto);
}