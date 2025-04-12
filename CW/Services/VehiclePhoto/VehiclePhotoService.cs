
using AutoMapper;
namespace Global;
public class VehiclePhotoService(IVehiclePhotoRepository repository,
IVehicleRepository vehicleRepository,
ILogger<VehiclePhotoService> logger) : IVehiclePhotoService
{
    public async Task<VehiclePhotoServiceDto> AddAsync(AddVehiclePhotoServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddVehiclePhotoServiceDto, AddVehiclePhotoRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddVehiclePhotoServiceDto, AddVehiclePhotoRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        vehicleRepository.GetByIdAsync(addRepositoryDto.VehicleId));
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehiclePhotoRepositoryDto, VehiclePhotoServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<VehiclePhotoRepositoryDto, VehiclePhotoServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(int id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<VehiclePhotoListServiceDto> GetAllAsync(VehiclePhotoQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehiclePhotoQueryServiceDto,VehiclePhotoQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<VehiclePhotoQueryServiceDto,VehiclePhotoQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehiclePhotoRepositoryDto,VehiclePhotoServiceDto>());
        var mapper2 = new Mapper(config2);
        return new VehiclePhotoListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<VehiclePhotoServiceDto>(x))
        };
    }

    public async Task<VehiclePhotoServiceDto> GetByIdAsync(int id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehiclePhotoRepositoryDto, VehiclePhotoServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<VehiclePhotoRepositoryDto, VehiclePhotoServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateVehiclePhotoServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateVehiclePhotoServiceDto, UpdateVehiclePhotoRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateVehiclePhotoServiceDto, UpdateVehiclePhotoRepositoryDto>(updateDto);
        await Task.WhenAll(
        updateDto.VehicleId.HasValue ? vehicleRepository.GetByIdAsync(updateDto.VehicleId.Value) : Task.CompletedTask);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}