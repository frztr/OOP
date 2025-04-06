using Automechanic.DTO;

namespace Automechanic;

public interface IService
{
    public EntityListDto GetAll();

    public EntityDto GetById(short id);

    public EntityDto Add(AddServiceDto addDto);

    public void Delete(short id);

    public void Update(UpdateDto updateDto);
}