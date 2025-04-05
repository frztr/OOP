
using Role.DTO;

namespace Role;

public class Service : BaseService<short, AddDto, EntityServiceDto, UpdateDto, AddDto, EntityRepositoryDto, UpdateDto, IRepository>, IService
{
    public Service(IRepository repository) : base(repository)
    {
    } 
}