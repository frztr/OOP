using System.Text.Json;

public class ServiceCreator
{
    public static string CreateService(Entity entity)
    {
        var pk = $@"{entity.Props.FirstOrDefault(x => x.PK).Type}";
        return $@"
using AutoMapper;
namespace Global;
public class {entity.Name}Service(I{entity.Name}Repository repository,
{String.Join("\n", entity.Props.Where(x => x.FK != null)
.Select(x => $"I{x.FK}Repository {JsonNamingPolicy.CamelCase.ConvertName(x.FK)}Repository,"))}
ILogger<{entity.Name}Service> logger) : I{entity.Name}Service
{{
    public async Task<{entity.Name}ServiceDto> AddAsync(Add{entity.Name}ServiceDto addServiceDto)
    {{
        logger.Log(LogLevel.Debug,""Add()"");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Add{entity.Name}ServiceDto, Add{entity.Name}RepositoryDto>());
        var mapper = new Mapper(config);
        var addRepositoryDto = mapper.Map<Add{entity.Name}ServiceDto, Add{entity.Name}RepositoryDto>(addServiceDto);
        await Task.WhenAll(
        {String.Join(",\n\t\t", entity.Props.Where(x => x.FK != null)
        .Select(x =>
        {
            if (x.IsRequired)
            {
                return $"{JsonNamingPolicy.CamelCase.ConvertName(x.FK)}Repository.GetByIdAsync(addRepositoryDto.{x.Name})";
            }
            else
            {
                return $@"addRepositoryDto.{x.Name}.HasValue ? {JsonNamingPolicy.CamelCase.ConvertName(x.FK)}Repository.GetByIdAsync(addRepositoryDto.{x.Name}.Value) : Task.CompletedTask";
            }
        }))});
        var entityRepositoryDto = await repository.AddAsync(addRepositoryDto);
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<{entity.Name}RepositoryDto, {entity.Name}ServiceDto>());
        var mapper2 = new Mapper(config2);
        return mapper2.Map<{entity.Name}RepositoryDto, {entity.Name}ServiceDto>(entityRepositoryDto);
    }}

    public async Task DeleteAsync({pk} id)
    {{
        logger.Log(LogLevel.Debug,""Delete()"");
        await repository.DeleteAsync(id);
    }}

    public async Task<{entity.Name}ListServiceDto> GetAllAsync({entity.Name}QueryServiceDto queryDto)
    {{
        logger.Log(LogLevel.Debug,""GetAll()"");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<{entity.Name}QueryServiceDto,{entity.Name}QueryRepositoryDto>());
        var mapper = new Mapper(config);
        var dto = mapper.Map<{entity.Name}QueryServiceDto,{entity.Name}QueryRepositoryDto>(queryDto);    
        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<{entity.Name}RepositoryDto,{entity.Name}ServiceDto>());
        var mapper2 = new Mapper(config2);
        return new {entity.Name}ListServiceDto(){{
            Items = (await repository.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<{entity.Name}ServiceDto>(x))
        }};
    }}

    public async Task<{entity.Name}ServiceDto> GetByIdAsync({pk} id)
    {{
        logger.Log(LogLevel.Debug,""GetById()"");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<{entity.Name}RepositoryDto, {entity.Name}ServiceDto>());
        var mapper = new Mapper(config);
        return mapper.Map<{entity.Name}RepositoryDto, {entity.Name}ServiceDto>(await repository.GetByIdAsync(id));
    }}

    public async Task UpdateAsync(Update{entity.Name}ServiceDto updateDto)
    {{
        logger.Log(LogLevel.Debug,""Update()"");
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Update{entity.Name}ServiceDto, Update{entity.Name}RepositoryDto>());
        var mapper = new Mapper(config);
        var updateRepositoryDto = mapper.Map<Update{entity.Name}ServiceDto, Update{entity.Name}RepositoryDto>(updateDto);
        await Task.WhenAll(
        {String.Join(",\n\t\t", entity.Props.Where(x => x.FK != null)
        .Select(x =>
        {

            return $@"updateDto.{x.Name}.HasValue ? {JsonNamingPolicy.CamelCase.ConvertName(x.FK)}Repository.GetByIdAsync(updateDto.{x.Name}.Value) : Task.CompletedTask";

        }))});
        await repository.UpdateAsync(updateRepositoryDto);
    }}
}}";
    }
}