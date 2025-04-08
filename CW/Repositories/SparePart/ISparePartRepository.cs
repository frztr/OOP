
        namespace Global;
        public interface ISparePartRepository
{
    public Task<SparePartListRepositoryDto> GetAllAsync(int count = 50, int offset = 0);

    public Task<SparePartRepositoryDto> GetByIdAsync(int id);

    public Task<SparePartRepositoryDto> AddAsync(AddSparePartRepositoryDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateSparePartRepositoryDto updateDto);
}