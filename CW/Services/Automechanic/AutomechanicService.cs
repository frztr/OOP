
using AutoMapper;
namespace Global;
public class AutomechanicService(IAutomechanicRepository repository) : IAutomechanicService
{
    public async Task<AutomechanicServiceDto> AddAsync(AddAutomechanicServiceDto addServiceDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddAutomechanicServiceDto, AddAutomechanicRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddAutomechanicServiceDto, AddAutomechanicRepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<AutomechanicRepositoryDto, AutomechanicServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<AutomechanicRepositoryDto, AutomechanicServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(short id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<AutomechanicListServiceDto> GetAllAsync(short count = 50, short offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AutomechanicRepositoryDto,AutomechanicServiceDto>());
        var mapper = new Mapper(config);
        return new AutomechanicListServiceDto(){
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<AutomechanicServiceDto>(x))
        };
    }

    public async Task<AutomechanicServiceDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AutomechanicRepositoryDto, AutomechanicServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<AutomechanicRepositoryDto, AutomechanicServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateAutomechanicServiceDto updateDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateAutomechanicServiceDto, UpdateAutomechanicRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateAutomechanicServiceDto, UpdateAutomechanicRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}