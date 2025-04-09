
        namespace Global;
        public interface IAutomechanicRepository
{
    public Task<AutomechanicListRepositoryDto> GetAllAsync(AutomechanicQueryRepositoryDto queryDto);

    public Task<AutomechanicRepositoryDto> GetByIdAsync(short id);

    public Task<AutomechanicRepositoryDto> AddAsync(AddAutomechanicRepositoryDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateAutomechanicRepositoryDto updateDto);
}