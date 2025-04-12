
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Mvc;
namespace Global;
[Authorize(Roles="admin")]
[ApiController]
[Route("PlannedMaintenanceSchedule")]
public class PlannedMaintenanceScheduleController(IPlannedMaintenanceScheduleService service) : Controller
{
    [HttpPost]
    [Route("add")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<IResult> Add(AddPlannedMaintenanceScheduleControllerDto addDto) 
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddPlannedMaintenanceScheduleControllerDto, AddPlannedMaintenanceScheduleServiceDto>());
            var mapper = new Mapper(config);
            var addServiceDto = mapper.Map<AddPlannedMaintenanceScheduleControllerDto, AddPlannedMaintenanceScheduleServiceDto>(addDto);
            var result = await service.AddAsync(addServiceDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<PlannedMaintenanceScheduleServiceDto, PlannedMaintenanceScheduleControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(mapper2.Map<PlannedMaintenanceScheduleServiceDto, PlannedMaintenanceScheduleControllerDto>(result));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(new {error = ex.Message});
        }
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<IResult> Delete(int id)
    {
        try
        {
            await service.DeleteAsync(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(new {error = ex.Message}); 
        }
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<IResult> GetAll([FromQuery]PlannedMaintenanceScheduleQueryControllerDto queryDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PlannedMaintenanceScheduleQueryControllerDto,PlannedMaintenanceScheduleQueryServiceDto>());
            var mapper = new Mapper(config);
            var dto = mapper.Map<PlannedMaintenanceScheduleQueryControllerDto,PlannedMaintenanceScheduleQueryServiceDto>(queryDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<PlannedMaintenanceScheduleServiceDto,PlannedMaintenanceScheduleControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(new PlannedMaintenanceScheduleListControllerDto(){
                Items = (await service.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<PlannedMaintenanceScheduleServiceDto,PlannedMaintenanceScheduleControllerDto>(x))
            });
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(new {error = ex.Message});
        }
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<IResult> GetById(int id)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PlannedMaintenanceScheduleServiceDto, PlannedMaintenanceScheduleControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(mapper.Map<PlannedMaintenanceScheduleServiceDto, PlannedMaintenanceScheduleControllerDto>(await service.GetByIdAsync(id)));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(new {error = ex.Message});
        }
    }
    [HttpPatch]
    [Route("update")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<IResult> UpdateAsync(UpdatePlannedMaintenanceScheduleControllerDto updateDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdatePlannedMaintenanceScheduleControllerDto, UpdatePlannedMaintenanceScheduleServiceDto>());
            var mapper = new Mapper(config);
            var updateServiceDto = mapper.Map<UpdatePlannedMaintenanceScheduleControllerDto, UpdatePlannedMaintenanceScheduleServiceDto>(updateDto);
            await service.UpdateAsync(updateServiceDto);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(new {error = ex.Message});
        }
    }
}
