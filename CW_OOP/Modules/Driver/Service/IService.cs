using Driver.DTO;

namespace Driver;

public interface IService
{
    public EntityRepositoryListDto GetAll();

    public EntityDto GetById(short id);

    public EntityDto Add(AddServiceDto addDto);

    public void Delete(short id);

    public void Update(UpdateDto updateDto);

    public EntityRefuelListDto GetRefuels(short id, int count = 50, int offset = 0);
}