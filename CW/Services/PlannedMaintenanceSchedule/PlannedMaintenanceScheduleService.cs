
using AutoMapper;
namespace Global;
public class PlannedMaintenanceScheduleService(IPlannedMaintenanceScheduleRepository repository) : IPlannedMaintenanceScheduleService
{
    public async Task<PlannedMaintenanceScheduleServiceDto> AddAsync(AddPlannedMaintenanceScheduleServiceDto addServiceDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddPlannedMaintenanceScheduleServiceDto, AddPlannedMaintenanceScheduleRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddPlannedMaintenanceScheduleServiceDto, AddPlannedMaintenanceScheduleRepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<PlannedMaintenanceScheduleRepositoryDto, PlannedMaintenanceScheduleServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<PlannedMaintenanceScheduleRepositoryDto, PlannedMaintenanceScheduleServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(int id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<PlannedMaintenanceScheduleListServiceDto> GetAllAsync(int count = 50, int offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<PlannedMaintenanceScheduleRepositoryDto,PlannedMaintenanceScheduleServiceDto>());
        var mapper = new Mapper(config);
        return new PlannedMaintenanceScheduleListServiceDto(){
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<PlannedMaintenanceScheduleServiceDto>(x))
        };
    }

    public async Task<PlannedMaintenanceScheduleServiceDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<PlannedMaintenanceScheduleRepositoryDto, PlannedMaintenanceScheduleServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<PlannedMaintenanceScheduleRepositoryDto, PlannedMaintenanceScheduleServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdatePlannedMaintenanceScheduleServiceDto updateDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdatePlannedMaintenanceScheduleServiceDto, UpdatePlannedMaintenanceScheduleRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdatePlannedMaintenanceScheduleServiceDto, UpdatePlannedMaintenanceScheduleRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}