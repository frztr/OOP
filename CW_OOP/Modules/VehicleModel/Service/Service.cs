
using VehicleModel.DTO;

namespace VehicleModel;

public class Service(IRepository repository,
FuelType.IRepository fuelTypeRepository,
Manufacturer.IRepository manufacturerRepository,
VehicleCategory.IRepository vehicleCategoryRepository) : IService
{
    public EntityDto Add(AddDto addDto)
    {
        return repository.Add(addDto);
    }

    public void Delete(int id)
    {
        repository.Delete(id);
    }

    public EntityListServiceDto GetAll(int count = 50, int offset = 0)
    {
        var items = repository.GetAll(count,offset).Items;
        return new EntityListServiceDto()
        {
            Items = items,
            FuelTypes = fuelTypeRepository.GetByIds(items.Select(x => x.FuelTypeId).Distinct().ToArray()).items,
            Manufacturers = manufacturerRepository.GetByIds(items.Select(x => x.ManufacturerId).Distinct().ToArray()).items,
            VehicleCategories = vehicleCategoryRepository.GetByIds(items.Select(x => x.VehicleCategoryId).Distinct().ToArray()).items
        };
    }

    public EntityDto GetById(int id)
    {
        return repository.GetById(id);
    }

    public void Update(UpdateDto updateDto)
    {
        repository.Update(updateDto);
    }
}