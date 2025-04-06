using Automechanic.DTO;

namespace Automechanic;
public interface IRepository
{
    public EntityListDto GetAll();

    public EntityDto GetById(short id);

    public EntityDto Add(AddRepositoryDto addDto);

    public void Delete(short id);

    public void Update(UpdateDto updateDto);
}