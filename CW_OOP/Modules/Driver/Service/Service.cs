
using Driver.DTO;

namespace Driver;

public class Service(
    IRepository repository,
    User.IRepository userRepository,
    Role.IRepository roleRepository,
    RefuelingHistory.IRepository refuelsRepository,
    Vehicle.IRepository vehicleRepository
) : IService
{
    public EntityDto Add(AddServiceDto addDto)
    {
        var role = roleRepository.GetAll().items.FirstOrDefault(x => x.Name == "driver");

        var user = userRepository.Add(new User.DTO.AddDto()
        {
            Fio = addDto.Fio,
            Login = addDto.Login,
            Password = addDto.Password,
            RoleId = role.Id
        });

        AddRepositoryDto dto = new AddRepositoryDto()
        {
            DriverLicense = addDto.DriverLicense,
            Experience = addDto.Experience,
            UserId = user.Id,
        };
        return repository.Add(dto);
    }

    public void Delete(short id)
    {
        repository.Delete(id);
    }

    public EntityRepositoryListDto GetAll()
    {
        return repository.GetAll();
    }

    public EntityDto GetById(short id)
    {
        return repository.GetById(id);
    }

    public EntityRefuelListDto GetRefuels(short id, int count = 50, int offset = 0)
    {
        var refuels = refuelsRepository.GetByDriverId(id, count, offset);
        return new EntityRefuelListDto()
        {
            items = refuels,
            vehicles = vehicleRepository.GetByIds(refuels.Items.Select(x => x.VehicleId).ToArray())
        };
    }

    public void Update(UpdateDto updateDto)
    {
        repository.Update(updateDto);
    }
}