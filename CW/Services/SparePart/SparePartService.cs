
using AutoMapper;
namespace Global;
public class SparePartService(ISparePartRepository repository,

ILogger<SparePartService> logger) : ISparePartService
{
    public async Task<SparePartServiceDto> AddAsync(AddSparePartServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddSparePartServiceDto, AddSparePartRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddSparePartServiceDto, AddSparePartRepositoryDto>(addServiceDto);
        await Task.WhenAll(
        );
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<SparePartRepositoryDto, SparePartServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<SparePartRepositoryDto, SparePartServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(int id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<SparePartListServiceDto> GetAllAsync(SparePartQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<SparePartQueryServiceDto,SparePartQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<SparePartQueryServiceDto,SparePartQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<SparePartRepositoryDto,SparePartServiceDto>());
        var mapper2 = new Mapper(config2);
        return new SparePartListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<SparePartServiceDto>(x))
        };
    }

    public async Task<SparePartServiceDto> GetByIdAsync(int id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<SparePartRepositoryDto, SparePartServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<SparePartRepositoryDto, SparePartServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateSparePartServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateSparePartServiceDto, UpdateSparePartRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateSparePartServiceDto, UpdateSparePartRepositoryDto>(updateDto);
        await Task.WhenAll(
        );
        await repository.UpdateAsync(updateRepositoryDto);
    }
}