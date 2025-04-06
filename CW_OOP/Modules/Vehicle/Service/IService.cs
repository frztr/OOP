using Vehicle.DTO;

namespace Vehicle;

public interface IService
{
    public EntityListDto GetAll(int count = 50, int offset = 0);

    public EntityDto GetById(int id);

    public EntityDto Add(AddDto addDto);

    public void Delete(int id);

    public void Update(UpdateDto updateDto);

    public EntityListServiceDto GetByIds(int[] ids, int count = 50, int offset = 0);
}