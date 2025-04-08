
        namespace Global;
        public interface IVehicleModelRepository
{
    public Task<VehicleModelListRepositoryDto> GetAllAsync(int count = 50, int offset = 0);

    public Task<VehicleModelRepositoryDto> GetByIdAsync(int id);

    public Task<VehicleModelRepositoryDto> AddAsync(AddVehicleModelRepositoryDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateVehicleModelRepositoryDto updateDto);
}