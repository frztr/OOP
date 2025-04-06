using VehicleModel.DTO;

namespace VehicleModel;
public interface IRepository
{
    public EntityListDto GetAll(int count = 50, int offset = 0);

    public EntityDto GetById(int id);

    public EntityDto Add(AddDto addDto);

    public void Delete(int id);

    public void Update(UpdateDto updateDto);

    public EntityListDto GetByIds(int[] ids, int count = 50, int offset = 0);
}