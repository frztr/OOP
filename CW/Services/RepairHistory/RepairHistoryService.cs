
using AutoMapper;
namespace Global;
public class RepairHistoryService(IRepairHistoryRepository repository) : IRepairHistoryService
{
    public async Task<RepairHistoryServiceDto> AddAsync(AddRepairHistoryServiceDto addServiceDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddRepairHistoryServiceDto, AddRepairHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddRepairHistoryServiceDto, AddRepairHistoryRepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<RepairHistoryRepositoryDto, RepairHistoryServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<RepairHistoryRepositoryDto, RepairHistoryServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(int id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<RepairHistoryListServiceDto> GetAllAsync(int count = 50, int offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<RepairHistoryRepositoryDto,RepairHistoryServiceDto>());
        var mapper = new Mapper(config);
        return new RepairHistoryListServiceDto(){
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<RepairHistoryServiceDto>(x))
        };
    }

    public async Task<RepairHistoryServiceDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<RepairHistoryRepositoryDto, RepairHistoryServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<RepairHistoryRepositoryDto, RepairHistoryServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateRepairHistoryServiceDto updateDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateRepairHistoryServiceDto, UpdateRepairHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateRepairHistoryServiceDto, UpdateRepairHistoryRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}