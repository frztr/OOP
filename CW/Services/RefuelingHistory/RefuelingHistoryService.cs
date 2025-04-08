
using AutoMapper;
namespace Global;
public class RefuelingHistoryService(IRefuelingHistoryRepository repository) : IRefuelingHistoryService
{
    public async Task<RefuelingHistoryServiceDto> AddAsync(AddRefuelingHistoryServiceDto addServiceDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddRefuelingHistoryServiceDto, AddRefuelingHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddRefuelingHistoryServiceDto, AddRefuelingHistoryRepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<RefuelingHistoryRepositoryDto, RefuelingHistoryServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<RefuelingHistoryRepositoryDto, RefuelingHistoryServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(int id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<RefuelingHistoryListServiceDto> GetAllAsync(int count = 50, int offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<RefuelingHistoryRepositoryDto,RefuelingHistoryServiceDto>());
        var mapper = new Mapper(config);
        return new RefuelingHistoryListServiceDto(){
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<RefuelingHistoryServiceDto>(x))
        };
    }

    public async Task<RefuelingHistoryServiceDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<RefuelingHistoryRepositoryDto, RefuelingHistoryServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<RefuelingHistoryRepositoryDto, RefuelingHistoryServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateRefuelingHistoryServiceDto updateDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateRefuelingHistoryServiceDto, UpdateRefuelingHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateRefuelingHistoryServiceDto, UpdateRefuelingHistoryRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}