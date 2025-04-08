
        namespace Global;
        public interface IManufacturerRepository
{
    public Task<ManufacturerListRepositoryDto> GetAllAsync(short count = 50, short offset = 0);

    public Task<ManufacturerRepositoryDto> GetByIdAsync(short id);

    public Task<ManufacturerRepositoryDto> AddAsync(AddManufacturerRepositoryDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateManufacturerRepositoryDto updateDto);
}