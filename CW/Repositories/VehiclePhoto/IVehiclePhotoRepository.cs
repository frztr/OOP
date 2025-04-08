
        namespace Global;
        public interface IVehiclePhotoRepository
{
    public Task<VehiclePhotoListRepositoryDto> GetAllAsync(int count = 50, int offset = 0);

    public Task<VehiclePhotoRepositoryDto> GetByIdAsync(int id);

    public Task<VehiclePhotoRepositoryDto> AddAsync(AddVehiclePhotoRepositoryDto addDto);

    public Task DeleteAsync(int id);

    public Task UpdateAsync(UpdateVehiclePhotoRepositoryDto updateDto);
}