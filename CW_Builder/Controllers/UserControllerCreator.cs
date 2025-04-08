public class UserControllerCreator
{
    public static string CreateController(Entity entity)
    {
        var pk = $@"{entity.Props.FirstOrDefault(x => x.Name == "Id").Type}";
        return $@"
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace Global;
[ApiController]
[Route(""{entity.Name}"")]
public class {entity.Name}Controller(I{entity.Name}Service service)
{{
    [HttpPost]
    [Route(""add"")]
    public async Task<IResult> Add(Add{entity.Name}ControllerDto addDto)
    {{
        try
        {{
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Add{entity.Name}ControllerDto, Add{entity.Name}ServiceDto>());
            var mapper = new Mapper(config);
            var addServiceDto = mapper.Map<Add{entity.Name}ControllerDto, Add{entity.Name}ServiceDto>(addDto);
            var result = await service.AddAsync(addServiceDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<{entity.Name}ServiceDto, {entity.Name}ControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(mapper2.Map<{entity.Name}ServiceDto, {entity.Name}ControllerDto>(result));
        }}
        catch (Exception ex)
        {{
            return Results.InternalServerError(ex);
        }}
    }}

    [HttpDelete]
    [Route(""{{id}}"")]
    public async Task<IResult> Delete({pk} id)
    {{
        try
        {{
            await service.DeleteAsync(id);
            return Results.Ok();
        }}
        catch (Exception ex)
        {{
            return Results.InternalServerError(ex);
        }}
    }}

    [HttpGet]
    [Route("""")]
    public async Task<IResult> GetAll({pk} count = 50, {pk} offset = 0)
    {{
        try
        {{
            var config = new MapperConfiguration(cfg => cfg.CreateMap<{entity.Name}ServiceDto,{entity.Name}ControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(new {entity.Name}ListControllerDto(){{
                Items = (await service.GetAllAsync(count,offset)).Items.Select(x=>mapper.Map<{entity.Name}ControllerDto>(x))
            }});
        }}
        catch (Exception ex)
        {{
            return Results.InternalServerError(ex);
        }}
    }}

    [HttpGet]
    [Route(""{{id}}"")]
    public async Task<IResult> GetById({pk} id)
    {{
        try
        {{
            var config = new MapperConfiguration(cfg => cfg.CreateMap<{entity.Name}ServiceDto, {entity.Name}ControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(mapper.Map<{entity.Name}ServiceDto, {entity.Name}ControllerDto>(await service.GetByIdAsync(id)));
        }}
        catch (Exception ex)
        {{
            return Results.InternalServerError(ex);
        }}
    }}
    [HttpPatch]
    [Route(""update"")]
    public async Task<IResult> UpdateAsync(Update{entity.Name}ControllerDto updateDto)
    {{
        try
        {{
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Update{entity.Name}ControllerDto, Update{entity.Name}ServiceDto>());
            var mapper = new Mapper(config);
            var updateServiceDto = mapper.Map<Update{entity.Name}ControllerDto, Update{entity.Name}ServiceDto>(updateDto);
            await service.UpdateAsync(updateServiceDto);
            return Results.Ok();
        }}
        catch (Exception ex)
        {{
            return Results.InternalServerError(ex);
        }}
    }}

    [HttpPost]
    [Route(""login"")]
    public async Task<IResult> Login(UserLoginControllerDto loginDto)
    {{
        try
        {{
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserLoginControllerDto, UserLoginServiceDto>());
            var mapper = new Mapper(config);
            var userLoginServiceDto = mapper.Map<UserLoginControllerDto, UserLoginServiceDto>(loginDto);
            
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<UserLoginResultServiceDto, UserLoginResultControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(mapper2.Map<UserLoginResultServiceDto, UserLoginResultControllerDto>(await service.Login(userLoginServiceDto)));
            
        }}
        catch (Exception ex)
        {{
            return Results.InternalServerError(ex);
        }}
    }}
}}
";
    }
}