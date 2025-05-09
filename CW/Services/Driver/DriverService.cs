
using AutoMapper;
namespace Global;

using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Logging;
public class DriverService(IDriverRepository repository,
IRoleRepository roleRepository,
IUserRepository userRepository,
ILogger<DriverService> logger) : IDriverService
{
    public async Task<DriverServiceDto> AddAsync(AddDriverServiceDto addServiceDto)
    {
        logger.Log(LogLevel.Debug, "Add()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddDriverServiceDto, AddDriverRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddDriverServiceDto, AddDriverRepositoryDto>(addServiceDto);

        var roles = await roleRepository.GetAllAsync(new RoleQueryRepositoryDto());
        var driverRole = roles.Items.FirstOrDefault(x => x.Name == "driver");

        var userMapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<AddDriverServiceDto, AddUserRepositoryDto>());
        var userMapper = new Mapper(userMapperConfig);
        var addUserDto = userMapper.Map<AddDriverServiceDto, AddUserRepositoryDto>(addServiceDto);

        addUserDto.RoleId = driverRole.Id;
        addUserDto.PasswordHash = Convert.ToHexString(
            MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(addServiceDto.Password))
        );
        var userDto = await userRepository.AddAsync(addUserDto);

        addRepositoryDto.UserId = userDto.Id;
        
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<DriverRepositoryDto, DriverServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<DriverRepositoryDto, DriverServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(short id)
    {
        logger.Log(LogLevel.Debug, "Delete()");
        await repository.DeleteAsync(id);
    }

    public async Task<DriverListServiceDto> GetAllAsync(DriverQueryServiceDto queryDto)
    {
        logger.Log(LogLevel.Debug, "GetAll()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<DriverQueryServiceDto, DriverQueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<DriverQueryServiceDto, DriverQueryRepositoryDto>(queryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<DriverRepositoryDto, DriverServiceDto>());
        var mapper2 = new Mapper(config2);
        return new DriverListServiceDto()
        {
            Items = (await repository.GetAllAsync(dto)).Items.Select(x => mapper2.Map<DriverServiceDto>(x))
        };
    }

    public async Task<DriverServiceDto> GetByIdAsync(short id)
    {
        logger.Log(LogLevel.Debug, "GetById()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<DriverRepositoryDto, DriverServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<DriverRepositoryDto, DriverServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateDriverServiceDto updateDto)
    {
        logger.Log(LogLevel.Debug, "Update()");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateDriverServiceDto, UpdateDriverRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateDriverServiceDto, UpdateDriverRepositoryDto>(updateDto);
        await Task.WhenAll(
        );
        await repository.UpdateAsync(updateRepositoryDto);
    }
}