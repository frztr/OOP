
using Vehicle.DTO;

namespace Vehicle;

public class Service(IRepository repository,
VehicleModel.IRepository vehicleModelRepository,
VehicleStatus.IRepository vehicleStatusRepository) : IService
{
    public EntityDto Add(AddDto addDto)
    {
        return repository.Add(addDto);
    }

    public void Delete(int id)
    {
        repository.Delete(id);
    }

    public EntityListDto GetAll(int count = 50, int offset = 0)
    {
        return repository.GetAll(count, offset);
    }

    public EntityDto GetById(int id)
    {
        return repository.GetById(id);
    }

    public EntityListServiceDto GetByIds(int[] ids, int count = 50, int offset = 0)
    {
        var dto = repository.GetByIds(ids, count, offset);
        return new EntityListServiceDto()
        {
            items = dto.items,
            vehicleModels = vehicleModelRepository.GetByIds(dto.items.Select(x => x.VehicleModelId).Distinct().ToArray()),
            vehicleStatuses = vehicleStatusRepository.GetByIds(dto.items.Select(x => x.StatusId).Distinct().ToArray()).items
        };
    }

    public void Update(UpdateDto updateDto)
    {
        repository.Update(updateDto);
    }
}