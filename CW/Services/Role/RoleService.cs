
using AutoMapper;
namespace Global;
public class RoleService(IRoleRepository repository) : IRoleService
{
    public async Task<RoleServiceDto> AddAsync(AddRoleServiceDto addServiceDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AddRoleServiceDto, AddRoleRepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<AddRoleServiceDto, AddRoleRepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<RoleRepositoryDto, RoleServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<RoleRepositoryDto, RoleServiceDto>(entityRepositoryDto);
    }

    public async Task DeleteAsync(short id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<RoleListServiceDto> GetAllAsync(short count = 50, short offset = 0)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<RoleRepositoryDto,RoleServiceDto>());
        var mapper = new Mapper(config);
        return new RoleListServiceDto(){
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<RoleServiceDto>(x))
        };
    }

    public async Task<RoleServiceDto> GetByIdAsync(short id)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<RoleRepositoryDto, RoleServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<RoleRepositoryDto, RoleServiceDto>(await repository.GetByIdAsync(id));
    }

    public async Task UpdateAsync(UpdateRoleServiceDto updateDto)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateRoleServiceDto, UpdateRoleRepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<UpdateRoleServiceDto, UpdateRoleRepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }
}