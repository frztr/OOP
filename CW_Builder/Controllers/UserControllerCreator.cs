public class UserControllerCreator
{
    public static string CreateController(Entity entity)
    {
        var pk = $@"{entity.Props.FirstOrDefault(x => x.PK).Type}";
        return $@"
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Global;
[Authorize(Roles=""admin"")]
[ApiController]
[Route(""{entity.Name}"")]
public class {entity.Name}Controller(I{entity.Name}Service service)
{{
    [HttpPost]
    [Route(""add"")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
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
        catch (EntityNotFoundException ex)
        {{
            return Results.BadRequest(new {{error = ex.Message}});
        }}
        catch (Exception ex)
        {{
            return Results.InternalServerError(new {{error = ex.Message}});
        }}
    }}

    [HttpDelete]
    [Route(""{{id}}"")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IResult> Delete({pk} id)
    {{
        try
        {{
            await service.DeleteAsync(id);
            return Results.Ok();
        }}
        catch (EntityNotFoundException ex)
        {{
            return Results.BadRequest(new {{error = ex.Message}});
        }}
        catch (Exception ex)
        {{
            return Results.InternalServerError(new {{error = ex.Message}});
        }}
    }}

    [HttpGet]
    [Route("""")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IResult> GetAll([FromQuery]{entity.Name}QueryControllerDto queryDto)
    {{
        try
        {{
            var config = new MapperConfiguration(cfg => cfg.CreateMap<{entity.Name}QueryControllerDto,{entity.Name}QueryServiceDto>());
            var mapper = new Mapper(config);
            var dto = mapper.Map<{entity.Name}QueryControllerDto,{entity.Name}QueryServiceDto>(queryDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<{entity.Name}ServiceDto,{entity.Name}ControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(new {entity.Name}ListControllerDto(){{
                Items = (await service.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<{entity.Name}ServiceDto,{entity.Name}ControllerDto>(x))
            }});
        }}
        catch (EntityNotFoundException ex)
        {{
            return Results.BadRequest(new {{error = ex.Message}});
        }}
        catch (Exception ex)
        {{
            return Results.InternalServerError(new {{error = ex.Message}});
        }}
    }}

    [HttpGet]
    [Route(""{{id}}"")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IResult> GetById({pk} id)
    {{
        try
        {{
            var config = new MapperConfiguration(cfg => cfg.CreateMap<{entity.Name}ServiceDto, {entity.Name}ControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(mapper.Map<{entity.Name}ServiceDto, {entity.Name}ControllerDto>(await service.GetByIdAsync(id)));
        }}
        catch (EntityNotFoundException ex)
        {{
            return Results.BadRequest(new {{error = ex.Message}});
        }}
        catch (Exception ex)
        {{
            return Results.InternalServerError(new {{error = ex.Message}});
        }}
    }}
    [HttpPatch]
    [Route(""update"")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
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
        catch (EntityNotFoundException ex)
        {{
            return Results.BadRequest(new {{error = ex.Message}});
        }}
        catch (Exception ex)
        {{
            return Results.InternalServerError(new {{error = ex.Message}});
        }}
    }}

    [HttpPost]
    [Route(""login"")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [AllowAnonymous]
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
        catch (BadLoginException ex)
        {{
            return Results.NotFound(new {{error = ex.Message}});
        }}
        catch (Exception ex)
        {{
            return Results.InternalServerError(new {{error = ex.Message}});
        }}
    }}
}}
";
    }
}