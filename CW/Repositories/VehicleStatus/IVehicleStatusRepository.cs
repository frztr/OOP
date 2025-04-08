
        namespace Global;
        public interface IVehicleStatusRepository
{
    public Task<VehicleStatusListRepositoryDto> GetAllAsync(short count = 50, short offset = 0);

    public Task<VehicleStatusRepositoryDto> GetByIdAsync(short id);

    public Task<VehicleStatusRepositoryDto> AddAsync(AddVehicleStatusRepositoryDto addDto);

    public Task DeleteAsync(short id);

    public Task UpdateAsync(UpdateVehicleStatusRepositoryDto updateDto);
}