
using AutoMapper;
namespace Global;
public class DriverService(IDriverRepository repository, ILogger<DriverService> logger) : IDriverService
{
    public async Task<DriverServiceDto> AddAsync(AddDriverServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug,"Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddDriverServiceDto, AddDriverRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddDriverServiceDto, AddDriverRepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<DriverRepositoryDto, DriverServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<DriverRepositoryDto, DriverServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(short id)
    {
        logger.Log(LogLevel.Debug,"Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<DriverListServiceDto> GetAllAsync(DriverQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug,"GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<DriverQueryServiceDto,DriverQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<DriverQueryServiceDto,DriverQueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<DriverRepositoryDto,DriverServiceDto>());
        var mapper2 = new Mapper(config2);
        return new DriverListServiceDto(){
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<DriverServiceDto>(x))
        };
    }

    public async Task<DriverServiceDto> GetByIdAsync(short id)
    {
        logger.Log(LogLevel.Debug,"GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<DriverRepositoryDto, DriverServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<DriverRepositoryDto, DriverServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateDriverServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug,"Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateDriverServiceDto, UpdateDriverRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateDriverServiceDto, UpdateDriverRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}