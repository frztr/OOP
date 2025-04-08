
        namespace Global;
        public interface IOilTypeRepository
{
    public Task<OilTypeListRepositoryDto> GetAllAsync(short count = 50, short offset = 0);

    public Task<OilTypeRepositoryDto> GetByIdAsync(short id);

    public Task<OilTypeRepositoryDto> AddAsync(AddOilTypeRepositoryDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateOilTypeRepositoryDto updateDto);
}