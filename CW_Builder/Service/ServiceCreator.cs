public class ServiceCreator
{
    public static string CreateService(Entity entity)
    {
        var pk = $@"{entity.Props.FirstOrDefault(x => x.PK).Type}";
        return $@"
using AutoMapper;
namespace Global;
public class {entity.Name}Service(I{entity.Name}Repository repository) : I{entity.Name}Service
{{
    public async Task<{entity.Name}ServiceDto> AddAsync(Add{entity.Name}ServiceDto addServiceDto)
    {{
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Add{entity.Name}ServiceDto, Add{entity.Name}RepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<Add{entity.Name}ServiceDto, Add{entity.Name}RepositoryDto>(addServiceDto);
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<{entity.Name}RepositoryDto, {entity.Name}ServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<{entity.Name}RepositoryDto, {entity.Name}ServiceDto>(entityRepositoryDto);
    }}

    public async Task DeleteAsync({pk} id)
    {{
        await repository.DeleteAsync(id);
    }}

    public async Task<{entity.Name}ListServiceDto> GetAllAsync({pk} count = 50, {pk} offset = 0)
    {{
        var config = new MapperConfiguration(cfg => cfg.CreateMap<{entity.Name}RepositoryDto,{entity.Name}ServiceDto>());
        var mapper = new Mapper(config);
        return new {entity.Name}ListServiceDto(){{
            Items = (await repository.GetAllAsync(count, offset)).Items.Select(x=>mapper.Map<{entity.Name}ServiceDto>(x))
        }};
    }}

    public async Task<{entity.Name}ServiceDto> GetByIdAsync({pk} id)
    {{
        var config = new MapperConfiguration(cfg => cfg.CreateMap<{entity.Name}RepositoryDto, {entity.Name}ServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<{entity.Name}RepositoryDto, {entity.Name}ServiceDto>(await repository.GetByIdAsync(id));
    }}

    public async Task UpdateAsync(Update{entity.Name}ServiceDto updateDto)
    {{
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Update{entity.Name}ServiceDto, Update{entity.Name}RepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<Update{entity.Name}ServiceDto, Update{entity.Name}RepositoryDto>(updateDto);
        await repository.UpdateAsync(updateRepositoryDto);
    }}
}}";
    }
}