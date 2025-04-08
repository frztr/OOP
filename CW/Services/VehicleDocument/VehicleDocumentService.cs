
using AutoMapper;
namespace Global;
public class VehicleDocumentService(IVehicleDocumentRepository repository) : IVehicleDocumentService
{
    public async Task<VehicleDocumentServiceDto> AddAsync(AddVehicleDocumentServiceDto addServiceDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddVehicleDocumentServiceDto, AddVehicleDocumentRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddVehicleDocumentServiceDto, AddVehicleDocumentRepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehicleDocumentRepositoryDto, VehicleDocumentServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<VehicleDocumentRepositoryDto, VehicleDocumentServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(int id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<VehicleDocumentListServiceDto> GetAllAsync(int count = 50, int offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleDocumentRepositoryDto,VehicleDocumentServiceDto>());
        var mapper = new Mapper(config);
        return new VehicleDocumentListServiceDto(){
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<VehicleDocumentServiceDto>(x))
        };
    }

    public async Task<VehicleDocumentServiceDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleDocumentRepositoryDto, VehicleDocumentServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<VehicleDocumentRepositoryDto, VehicleDocumentServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateVehicleDocumentServiceDto updateDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateVehicleDocumentServiceDto, UpdateVehicleDocumentRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateVehicleDocumentServiceDto, UpdateVehicleDocumentRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}