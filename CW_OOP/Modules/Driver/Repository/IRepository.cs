using Driver.DTO;

namespace Driver;
public interface IRepository
{
    public EntityRepositoryListDto GetAll();

    public EntityDto GetById(short id);

    public EntityDto Add(AddRepositoryDto addDto);

    public void Delete(short id);

    public void Update(UpdateDto updateDto);
}