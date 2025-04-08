
using AutoMapper;
namespace Global;
public class MileageMeasurementHistoryService(IMileageMeasurementHistoryRepository repository) : IMileageMeasurementHistoryService
{
    public async Task<MileageMeasurementHistoryServiceDto> AddAsync(AddMileageMeasurementHistoryServiceDto addServiceDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddMileageMeasurementHistoryServiceDto, AddMileageMeasurementHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddMileageMeasurementHistoryServiceDto, AddMileageMeasurementHistoryRepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<MileageMeasurementHistoryRepositoryDto, MileageMeasurementHistoryServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<MileageMeasurementHistoryRepositoryDto, MileageMeasurementHistoryServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(int id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<MileageMeasurementHistoryListServiceDto> GetAllAsync(int count = 50, int offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<MileageMeasurementHistoryRepositoryDto,MileageMeasurementHistoryServiceDto>());
        var mapper = new Mapper(config);
        return new MileageMeasurementHistoryListServiceDto(){
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<MileageMeasurementHistoryServiceDto>(x))
        };
    }

    public async Task<MileageMeasurementHistoryServiceDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<MileageMeasurementHistoryRepositoryDto, MileageMeasurementHistoryServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<MileageMeasurementHistoryRepositoryDto, MileageMeasurementHistoryServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateMileageMeasurementHistoryServiceDto updateDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateMileageMeasurementHistoryServiceDto, UpdateMileageMeasurementHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateMileageMeasurementHistoryServiceDto, UpdateMileageMeasurementHistoryRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}