
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Mvc;
namespace Global;
[Authorize(Roles="admin")]
[ApiController]
[Route("Automechanic")]
public class AutomechanicController(IAutomechanicService service) : Controller
{
    [HttpPost]
    [Route("add")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<IResult> Add(AddAutomechanicControllerDto addDto) 
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddAutomechanicControllerDto, AddAutomechanicServiceDto>());
            var mapper = new Mapper(config);
            var addServiceDto = mapper.Map<AddAutomechanicControllerDto, AddAutomechanicServiceDto>(addDto);
            var result = await service.AddAsync(addServiceDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<AutomechanicServiceDto, AutomechanicControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(mapper2.Map<AutomechanicServiceDto, AutomechanicControllerDto>(result));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
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
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<IResult> GetAll([FromQuery]AutomechanicQueryControllerDto queryDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AutomechanicQueryControllerDto,AutomechanicQueryServiceDto>());
            var mapper = new Mapper(config);
            var dto = mapper.Map<AutomechanicQueryControllerDto,AutomechanicQueryServiceDto>(queryDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<AutomechanicServiceDto,AutomechanicControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(new AutomechanicListControllerDto(){
                Items = (await service.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<AutomechanicServiceDto,AutomechanicControllerDto>(x))
            });
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<IResult> GetById(short id)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AutomechanicServiceDto, AutomechanicControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(mapper.Map<AutomechanicServiceDto, AutomechanicControllerDto>(await service.GetByIdAsync(id)));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
    [HttpPatch]
    [Route("update")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<IResult> UpdateAsync(UpdateAutomechanicControllerDto updateDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateAutomechanicControllerDto, UpdateAutomechanicServiceDto>());
            var mapper = new Mapper(config);
            var updateServiceDto = mapper.Map<UpdateAutomechanicControllerDto, UpdateAutomechanicServiceDto>(updateDto);
            await service.UpdateAsync(updateServiceDto);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
}
