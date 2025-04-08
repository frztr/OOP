
        namespace Global;
        public interface IFuelTypeRepository
{
    public Task<FuelTypeListRepositoryDto> GetAllAsync(short count = 50, short offset = 0);

    public Task<FuelTypeRepositoryDto> GetByIdAsync(short id);

    public Task<FuelTypeRepositoryDto> AddAsync(AddFuelTypeRepositoryDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateFuelTypeRepositoryDto updateDto);
}