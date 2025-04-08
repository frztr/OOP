
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace Global;
[ApiController]
[Route("Role")]
public class RoleController(IRoleService service)
{
    [HttpPost]
    [Route("add")]
    public async Task<IResult> Add(AddRoleControllerDto addDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddRoleControllerDto, AddRoleServiceDto>());
            var mapper = new Mapper(config);
            var addServiceDto = mapper.Map<AddRoleControllerDto, AddRoleServiceDto>(addDto);
            var result = await service.AddAsync(addServiceDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<RoleServiceDto, RoleControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(mapper2.Map<RoleServiceDto, RoleControllerDto>(result));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IResult> Delete(short id)
    {
        try
        {
            await service.DeleteAsync(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }

    [HttpGet]
    [Route("")]
    public async Task<IResult> GetAll(short count = 50, short offset = 0)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RoleServiceDto,RoleControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(new RoleListControllerDto(){
                Items = (await service.GetAllAsync(count,offset)).Items.Select(x=>mapper.Map<RoleServiceDto,RoleControllerDto>(x))
            });
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IResult> GetById(short id)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RoleServiceDto, RoleControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(mapper.Map<RoleServiceDto, RoleControllerDto>(await service.GetByIdAsync(id)));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
    [HttpPatch]
    [Route("update")]
    public async Task<IResult> UpdateAsync(UpdateRoleControllerDto updateDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateRoleControllerDto, UpdateRoleServiceDto>());
            var mapper = new Mapper(config);
            var updateServiceDto = mapper.Map<UpdateRoleControllerDto, UpdateRoleServiceDto>(updateDto);
            await service.UpdateAsync(updateServiceDto);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
}
