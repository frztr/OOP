
using AutoMapper;
namespace Global;
public class RepairHistoryService(IRepairHistoryRepository repository, ILogger<RepairHistoryService> logger) : IRepairHistoryService
{
    public async Task<RepairHistoryServiceDto> AddAsync(AddRepairHistoryServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
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
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<RepairHistoryListServiceDto> GetAllAsync(RepairHistoryQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<RepairHistoryQueryServiceDto,RepairHistoryQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<RepairHistoryQueryServiceDto,RepairHistoryQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<RepairHistoryRepositoryDto,RepairHistoryServiceDto>());
        var mapper2 = new Mapper(config2);
        return new RepairHistoryListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<RepairHistoryServiceDto>(x))
        };
    }

    public async Task<RepairHistoryServiceDto> GetByIdAsync(int id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<RepairHistoryRepositoryDto, RepairHistoryServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<RepairHistoryRepositoryDto, RepairHistoryServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateRepairHistoryServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateRepairHistoryServiceDto, UpdateRepairHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateRepairHistoryServiceDto, UpdateRepairHistoryRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}