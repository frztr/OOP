using VehicleCategory.DTO;

namespace VehicleCategory;
public interface IRepository
{
    public EntityListDto GetAll();

    public EntityListDto GetByIds(short[] ids);

    public EntityDto GetById(short id);

    public EntityDto Add(AddDto addDto);

    public void Delete(short id);

    public void Update(UpdateDto updateDto);
}