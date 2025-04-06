using RefuelingHistory.DTO;

namespace RefuelingHistory;
public interface IRepository
{
    public EntityListDto GetAll(int count = 50, int offset = 0);

    public EntityDto GetById(short id);

    public EntityDto Add(AddDto addDto);

    public void Delete(short id);

    public void Update(UpdateDto updateDto);

    public EntityListDto GetByVehicleId(int vehicleId,int count = 50, int offset = 0);

    public EntityListDto GetByDriverId(int driverId,int count = 50, int offset = 0);
}