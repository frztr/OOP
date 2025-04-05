
namespace Driver;

public class Service(IRepository repository) : IService
{
    public void Add(DTO.AddDto addDto)
    {
        repository.Add(addDto);
    }

    public void Delete(short id)
    {
        repository.Delete(id);
    }

    public IEnumerable<DTO.EntityDto> GetAll()
    {
        return repository.GetAll();
    }

    public DTO.EntityDto GetById(short id)
    {
        return repository.GetById(id);
    }

    public void Update(DTO.UpdateDto updateDto)
    {
        repository.Update(updateDto);
    }
}