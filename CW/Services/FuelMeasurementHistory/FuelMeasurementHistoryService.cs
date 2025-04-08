
using AutoMapper;
namespace Global;
public class FuelMeasurementHistoryService(IFuelMeasurementHistoryRepository repository) : IFuelMeasurementHistoryService
{
    public async Task<FuelMeasurementHistoryServiceDto> AddAsync(AddFuelMeasurementHistoryServiceDto addServiceDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddFuelMeasurementHistoryServiceDto, AddFuelMeasurementHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddFuelMeasurementHistoryServiceDto, AddFuelMeasurementHistoryRepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<FuelMeasurementHistoryRepositoryDto, FuelMeasurementHistoryServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<FuelMeasurementHistoryRepositoryDto, FuelMeasurementHistoryServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(int id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<FuelMeasurementHistoryListServiceDto> GetAllAsync(int count = 50, int offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<FuelMeasurementHistoryRepositoryDto,FuelMeasurementHistoryServiceDto>());
        var mapper = new Mapper(config);
        return new FuelMeasurementHistoryListServiceDto(){
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<FuelMeasurementHistoryServiceDto>(x))
        };
    }

    public async Task<FuelMeasurementHistoryServiceDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<FuelMeasurementHistoryRepositoryDto, FuelMeasurementHistoryServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<FuelMeasurementHistoryRepositoryDto, FuelMeasurementHistoryServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateFuelMeasurementHistoryServiceDto updateDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateFuelMeasurementHistoryServiceDto, UpdateFuelMeasurementHistoryRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateFuelMeasurementHistoryServiceDto, UpdateFuelMeasurementHistoryRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}