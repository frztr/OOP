
using RefuelingHistory.DTO;

namespace RefuelingHistory;

public class Service(IRepository repository) : IService
{
    public EntityDto Add(AddDto addDto)
    {
        return repository.Add(addDto);
    }

    public void Delete(short id)
    {
        repository.Delete(id);
    }

    public EntityListDto GetAll()
    {
        return repository.GetAll();
    }

    public EntityDto GetById(short id)
    {
        return repository.GetById(id);
    }

    public void Update(UpdateDto updateDto)
    {
        repository.Update(updateDto);
    }
}