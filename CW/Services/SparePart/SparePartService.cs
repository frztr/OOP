
using AutoMapper;
namespace Global;
public class SparePartService(ISparePartRepository repository) : ISparePartService
{
    public async Task<SparePartServiceDto> AddAsync(AddSparePartServiceDto addServiceDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddSparePartServiceDto, AddSparePartRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddSparePartServiceDto, AddSparePartRepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<SparePartRepositoryDto, SparePartServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<SparePartRepositoryDto, SparePartServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(int id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<SparePartListServiceDto> GetAllAsync(int count = 50, int offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<SparePartRepositoryDto,SparePartServiceDto>());
        var mapper = new Mapper(config);
        return new SparePartListServiceDto(){
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<SparePartServiceDto>(x))
        };
    }

    public async Task<SparePartServiceDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<SparePartRepositoryDto, SparePartServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<SparePartRepositoryDto, SparePartServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateSparePartServiceDto updateDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateSparePartServiceDto, UpdateSparePartRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateSparePartServiceDto, UpdateSparePartRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}