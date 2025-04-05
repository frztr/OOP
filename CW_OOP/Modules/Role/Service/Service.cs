
using Role.DTO;

namespace Role;

public class Service : BaseService<short, AddDto, EntityDto, UpdateDto, AddDto, EntityDto, UpdateDto>, IService
{
    public Service(IBaseRepository<short, AddDto, UpdateDto, EntityDto> repository) : base(repository)
    {
    }
}