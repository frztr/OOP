
using AutoMapper;
namespace Global;
public class VehiclePhotoService(IVehiclePhotoRepository repository) : IVehiclePhotoService
{
    public async Task<VehiclePhotoServiceDto> AddAsync(AddVehiclePhotoServiceDto addServiceDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddVehiclePhotoServiceDto, AddVehiclePhotoRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddVehiclePhotoServiceDto, AddVehiclePhotoRepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehiclePhotoRepositoryDto, VehiclePhotoServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<VehiclePhotoRepositoryDto, VehiclePhotoServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(int id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<VehiclePhotoListServiceDto> GetAllAsync(int count = 50, int offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehiclePhotoRepositoryDto,VehiclePhotoServiceDto>());
        var mapper = new Mapper(config);
        return new VehiclePhotoListServiceDto(){
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<VehiclePhotoServiceDto>(x))
        };
    }

    public async Task<VehiclePhotoServiceDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehiclePhotoRepositoryDto, VehiclePhotoServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<VehiclePhotoRepositoryDto, VehiclePhotoServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateVehiclePhotoServiceDto updateDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateVehiclePhotoServiceDto, UpdateVehiclePhotoRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateVehiclePhotoServiceDto, UpdateVehiclePhotoRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}