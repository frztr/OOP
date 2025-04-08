
using AutoMapper;
namespace Global;
public class FuelTypeService(IFuelTypeRepository repository) : IFuelTypeService
{
    public async Task<FuelTypeServiceDto> AddAsync(AddFuelTypeServiceDto addServiceDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddFuelTypeServiceDto, AddFuelTypeRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddFuelTypeServiceDto, AddFuelTypeRepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<FuelTypeRepositoryDto, FuelTypeServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<FuelTypeRepositoryDto, FuelTypeServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(short id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<FuelTypeListServiceDto> GetAllAsync(short count = 50, short offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<FuelTypeRepositoryDto,FuelTypeServiceDto>());
        var mapper = new Mapper(config);
        return new FuelTypeListServiceDto(){
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<FuelTypeServiceDto>(x))
        };
    }

    public async Task<FuelTypeServiceDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<FuelTypeRepositoryDto, FuelTypeServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<FuelTypeRepositoryDto, FuelTypeServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateFuelTypeServiceDto updateDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateFuelTypeServiceDto, UpdateFuelTypeRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateFuelTypeServiceDto, UpdateFuelTypeRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}