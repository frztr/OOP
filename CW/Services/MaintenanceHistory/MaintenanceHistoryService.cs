
using AutoMapper;
namespace Global;
public class MaintenanceHistoryService(IMaintenanceHistoryRepository repository) : IMaintenanceHistoryService
{
    public async Task<MaintenanceHistoryServiceDto> AddAsync(AddMaintenanceHistoryServiceDto addServiceDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddMaintenanceHistoryServiceDto, AddMaintenanceHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddMaintenanceHistoryServiceDto, AddMaintenanceHistoryRepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<MaintenanceHistoryRepositoryDto, MaintenanceHistoryServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<MaintenanceHistoryRepositoryDto, MaintenanceHistoryServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(int id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<MaintenanceHistoryListServiceDto> GetAllAsync(int count = 50, int offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<MaintenanceHistoryRepositoryDto,MaintenanceHistoryServiceDto>());
        var mapper = new Mapper(config);
        return new MaintenanceHistoryListServiceDto(){
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<MaintenanceHistoryServiceDto>(x))
        };
    }

    public async Task<MaintenanceHistoryServiceDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<MaintenanceHistoryRepositoryDto, MaintenanceHistoryServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<MaintenanceHistoryRepositoryDto, MaintenanceHistoryServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateMaintenanceHistoryServiceDto updateDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateMaintenanceHistoryServiceDto, UpdateMaintenanceHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateMaintenanceHistoryServiceDto, UpdateMaintenanceHistoryRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}