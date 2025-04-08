
        namespace Global;
        public interface IVehicleRepository
{
    public Task<VehicleListRepositoryDto> GetAllAsync(int count = 50, int offset = 0);

    public Task<VehicleRepositoryDto> GetByIdAsync(int id);

    public Task<VehicleRepositoryDto> AddAsync(AddVehicleRepositoryDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateVehicleRepositoryDto updateDto);
}