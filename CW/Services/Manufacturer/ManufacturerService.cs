
using AutoMapper;
namespace Global;
public class ManufacturerService(IManufacturerRepository repository) : IManufacturerService
{
    public async Task<ManufacturerServiceDto> AddAsync(AddManufacturerServiceDto addServiceDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddManufacturerServiceDto, AddManufacturerRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddManufacturerServiceDto, AddManufacturerRepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<ManufacturerRepositoryDto, ManufacturerServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<ManufacturerRepositoryDto, ManufacturerServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(short id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<ManufacturerListServiceDto> GetAllAsync(short count = 50, short offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<ManufacturerRepositoryDto,ManufacturerServiceDto>());
        var mapper = new Mapper(config);
        return new ManufacturerListServiceDto(){
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<ManufacturerServiceDto>(x))
        };
    }

    public async Task<ManufacturerServiceDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<ManufacturerRepositoryDto, ManufacturerServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<ManufacturerRepositoryDto, ManufacturerServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateManufacturerServiceDto updateDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateManufacturerServiceDto, UpdateManufacturerRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateManufacturerServiceDto, UpdateManufacturerRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}