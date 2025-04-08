
using AutoMapper;
namespace Global;
public class MaintenanceTypeService(IMaintenanceTypeRepository repository) : IMaintenanceTypeService
{
    public async Task<MaintenanceTypeServiceDto> AddAsync(AddMaintenanceTypeServiceDto addServiceDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddMaintenanceTypeServiceDto, AddMaintenanceTypeRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddMaintenanceTypeServiceDto, AddMaintenanceTypeRepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<MaintenanceTypeRepositoryDto, MaintenanceTypeServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<MaintenanceTypeRepositoryDto, MaintenanceTypeServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(short id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<MaintenanceTypeListServiceDto> GetAllAsync(short count = 50, short offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<MaintenanceTypeRepositoryDto,MaintenanceTypeServiceDto>());
        var mapper = new Mapper(config);
        return new MaintenanceTypeListServiceDto(){
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<MaintenanceTypeServiceDto>(x))
        };
    }

    public async Task<MaintenanceTypeServiceDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<MaintenanceTypeRepositoryDto, MaintenanceTypeServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<MaintenanceTypeRepositoryDto, MaintenanceTypeServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateMaintenanceTypeServiceDto updateDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateMaintenanceTypeServiceDto, UpdateMaintenanceTypeRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateMaintenanceTypeServiceDto, UpdateMaintenanceTypeRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}