
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace Global;
[ApiController]
[Route("PlannedMaintenanceSchedule")]
public class PlannedMaintenanceScheduleController(IPlannedMaintenanceScheduleService service)
{
    [HttpPost]
    [Route("add")]
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
            return Results.InternalServerError(ex);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IResult> Delete(int id)
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
    public async Task<IResult> GetAll(int count = 50, int offset = 0)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PlannedMaintenanceScheduleServiceDto,PlannedMaintenanceScheduleControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(new PlannedMaintenanceScheduleListControllerDto(){
                Items = (await service.GetAllAsync(count,offset)).Items.Select(x=>mapper.Map<PlannedMaintenanceScheduleServiceDto,PlannedMaintenanceScheduleControllerDto>(x))
            });
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }

    [HttpGet]
    [Route("{id}")]
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
            return Results.InternalServerError(ex);
        }
    }
    [HttpPatch]
    [Route("update")]
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
            return Results.InternalServerError(ex);
        }
    }
}
