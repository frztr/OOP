
        namespace Global;
        public interface IVehicleCategoryRepository
{
    public Task<VehicleCategoryListRepositoryDto> GetAllAsync(short count = 50, short offset = 0);

    public Task<VehicleCategoryRepositoryDto> GetByIdAsync(short id);

    public Task<VehicleCategoryRepositoryDto> AddAsync(AddVehicleCategoryRepositoryDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateVehicleCategoryRepositoryDto updateDto);
}