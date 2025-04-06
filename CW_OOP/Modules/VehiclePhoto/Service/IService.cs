using VehiclePhoto.DTO;

namespace VehiclePhoto;

public interface IService
{
    public EntityListDto GetByVehicleId(int id);

    public EntityListDto Add(AddServiceDto addDto);

    public void Delete(int id);

}