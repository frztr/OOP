
using AutoMapper;
namespace Global;
public class RepairConsumedSparePartService(IRepairConsumedSparePartRepository repository) : IRepairConsumedSparePartService
{
    public async Task<RepairConsumedSparePartServiceDto> AddAsync(AddRepairConsumedSparePartServiceDto addServiceDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddRepairConsumedSparePartServiceDto, AddRepairConsumedSparePartRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddRepairConsumedSparePartServiceDto, AddRepairConsumedSparePartRepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<RepairConsumedSparePartRepositoryDto, RepairConsumedSparePartServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<RepairConsumedSparePartRepositoryDto, RepairConsumedSparePartServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(int id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<RepairConsumedSparePartListServiceDto> GetAllAsync(int count = 50, int offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<RepairConsumedSparePartRepositoryDto,RepairConsumedSparePartServiceDto>());
        var mapper = new Mapper(config);
        return new RepairConsumedSparePartListServiceDto(){
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<RepairConsumedSparePartServiceDto>(x))
        };
    }

    public async Task<RepairConsumedSparePartServiceDto> GetByIdAsync(int id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<RepairConsumedSparePartRepositoryDto, RepairConsumedSparePartServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<RepairConsumedSparePartRepositoryDto, RepairConsumedSparePartServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateRepairConsumedSparePartServiceDto updateDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateRepairConsumedSparePartServiceDto, UpdateRepairConsumedSparePartRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateRepairConsumedSparePartServiceDto, UpdateRepairConsumedSparePartRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}