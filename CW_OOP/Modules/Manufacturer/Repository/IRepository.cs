using Manufacturer.DTO;

namespace Manufacturer;
public interface IRepository
{
    public EntityListDto GetAll(short count = 50, short offset = 0);

    public EntityListDto GetByIds(short[] ids, short count = 50, short offset = 0);
    public EntityDto GetById(short id);

    public EntityDto Add(AddDto addDto);

    public void Delete(short id);

    public void Update(UpdateDto updateDto);
}