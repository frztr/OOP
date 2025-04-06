
using Automechanic.DTO;

namespace Automechanic;

public class Service(IRepository repository,
Role.IRepository roleRepository,
User.IRepository userRepository) : IService
{
    public EntityDto Add(AddServiceDto addDto)
    {
        var role = roleRepository.GetAll().items.FirstOrDefault(x => x.Name == "automechanic");

        var user = userRepository.Add(new User.DTO.AddDto()
        {
            Fio = addDto.Fio,
            Login = addDto.Login,
            Password = addDto.Password,
            RoleId = role.Id
        });

        AddRepositoryDto dto = new AddRepositoryDto()
        {
            Qualification = addDto.Qualification,
            UserId = user.Id,
        };
        return repository.Add(dto);
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