
using AutoMapper;
namespace Global;
public class VehicleDocumentService(IVehicleDocumentRepository repository,
IDocumentTypeRepository documentTypeRepository,
IVehicleRepository vehicleRepository,
ILogger<VehicleDocumentService> logger) : IVehicleDocumentService
{
    public async Task<VehicleDocumentServiceDto> AddAsync(AddVehicleDocumentServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddVehicleDocumentServiceDto, AddVehicleDocumentRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddVehicleDocumentServiceDto, AddVehicleDocumentRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        documentTypeRepository.GetByIdAsync(addRepositoryDto.DoctypeId),
		vehicleRepository.GetByIdAsync(addRepositoryDto.VehicleId));
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehicleDocumentRepositoryDto, VehicleDocumentServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<VehicleDocumentRepositoryDto, VehicleDocumentServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(int id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<VehicleDocumentListServiceDto> GetAllAsync(VehicleDocumentQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleDocumentQueryServiceDto,VehicleDocumentQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<VehicleDocumentQueryServiceDto,VehicleDocumentQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehicleDocumentRepositoryDto,VehicleDocumentServiceDto>());
        var mapper2 = new Mapper(config2);
        return new VehicleDocumentListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<VehicleDocumentServiceDto>(x))
        };
    }

    public async Task<VehicleDocumentServiceDto> GetByIdAsync(int id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleDocumentRepositoryDto, VehicleDocumentServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<VehicleDocumentRepositoryDto, VehicleDocumentServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateVehicleDocumentServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateVehicleDocumentServiceDto, UpdateVehicleDocumentRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateVehicleDocumentServiceDto, UpdateVehicleDocumentRepositoryDto>(updateDto);
        await Task.WhenAll(
        updateDto.DoctypeId.HasValue ? documentTypeRepository.GetByIdAsync(updateDto.DoctypeId.Value) : Task.CompletedTask,
		updateDto.VehicleId.HasValue ? vehicleRepository.GetByIdAsync(updateDto.VehicleId.Value) : Task.CompletedTask);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}