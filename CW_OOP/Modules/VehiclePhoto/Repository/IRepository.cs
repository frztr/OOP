using VehiclePhoto.DTO;

namespace VehiclePhoto;
public interface IRepository
{
    public EntityListDto GetByVehicleId(int id);

    public EntityDto Add(AddDto addDto);

    public void Delete(int id);

}