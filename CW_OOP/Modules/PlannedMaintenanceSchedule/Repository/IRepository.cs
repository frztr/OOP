using PlannedMaintenanceSchedule.DTO;

namespace PlannedMaintenanceSchedule;
public interface IRepository
{
    public EntityListDto GetAll();

    public EntityDto GetById(short id);

    public EntityDto Add(AddDto addDto);

    public void Delete(short id);

    public void Update(UpdateDto updateDto);
}