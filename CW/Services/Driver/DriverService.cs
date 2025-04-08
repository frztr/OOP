
using AutoMapper;
namespace Global;
public class DriverService(IDriverRepository repository) : IDriverService
{
    public async Task<DriverServiceDto> AddAsync(AddDriverServiceDto addServiceDto)
    {
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
        await repository.DeleteAsync(id);
    }

    public async Task<DriverListServiceDto> GetAllAsync(short count = 50, short offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<DriverRepositoryDto,DriverServiceDto>());
        var mapper = new Mapper(config);
        return new DriverListServiceDto(){
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<DriverServiceDto>(x))
        };
    }

    public async Task<DriverServiceDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<DriverRepositoryDto, DriverServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<DriverRepositoryDto, DriverServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateDriverServiceDto updateDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateDriverServiceDto, UpdateDriverRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateDriverServiceDto, UpdateDriverRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}