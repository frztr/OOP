
using AutoMapper;
namespace Global;
public class RepairConsumedSparePartService(IRepairConsumedSparePartRepository repository, ILogger<RepairConsumedSparePartService> logger) : IRepairConsumedSparePartService
{
    public async Task<RepairConsumedSparePartServiceDto> AddAsync(AddRepairConsumedSparePartServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddRepairConsumedSparePartServiceDto, AddRepairConsumedSparePartRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddRepairConsumedSparePartServiceDto, AddRepairConsumedSparePartRepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<RepairConsumedSparePartRepositoryDto, RepairConsumedSparePartServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<RepairConsumedSparePartRepositoryDto, RepairConsumedSparePartServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(int id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<RepairConsumedSparePartListServiceDto> GetAllAsync(RepairConsumedSparePartQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<RepairConsumedSparePartQueryServiceDto,RepairConsumedSparePartQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<RepairConsumedSparePartQueryServiceDto,RepairConsumedSparePartQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<RepairConsumedSparePartRepositoryDto,RepairConsumedSparePartServiceDto>());
        var mapper2 = new Mapper(config2);
        return new RepairConsumedSparePartListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<RepairConsumedSparePartServiceDto>(x))
        };
    }

    public async Task<RepairConsumedSparePartServiceDto> GetByIdAsync(int id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<RepairConsumedSparePartRepositoryDto, RepairConsumedSparePartServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<RepairConsumedSparePartRepositoryDto, RepairConsumedSparePartServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateRepairConsumedSparePartServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateRepairConsumedSparePartServiceDto, UpdateRepairConsumedSparePartRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateRepairConsumedSparePartServiceDto, UpdateRepairConsumedSparePartRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}