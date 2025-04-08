
using AutoMapper;
namespace Global;
public class OilTypeService(IOilTypeRepository repository) : IOilTypeService
{
    public async Task<OilTypeServiceDto> AddAsync(AddOilTypeServiceDto addServiceDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddOilTypeServiceDto, AddOilTypeRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddOilTypeServiceDto, AddOilTypeRepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<OilTypeRepositoryDto, OilTypeServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<OilTypeRepositoryDto, OilTypeServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(short id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<OilTypeListServiceDto> GetAllAsync(short count = 50, short offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<OilTypeRepositoryDto,OilTypeServiceDto>());
        var mapper = new Mapper(config);
        return new OilTypeListServiceDto(){
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<OilTypeServiceDto>(x))
        };
    }

    public async Task<OilTypeServiceDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<OilTypeRepositoryDto, OilTypeServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<OilTypeRepositoryDto, OilTypeServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateOilTypeServiceDto updateDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateOilTypeServiceDto, UpdateOilTypeRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateOilTypeServiceDto, UpdateOilTypeRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}