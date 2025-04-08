
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace Global;
[Authorize(Roles="admin")]
[ApiController]
[Route("MaintenanceType")]
public class MaintenanceTypeController(IMaintenanceTypeService service)
{
    [HttpPost]
    [Route("add")]
    public async Task<IResult> Add(AddMaintenanceTypeControllerDto addDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddMaintenanceTypeControllerDto, AddMaintenanceTypeServiceDto>());
            var mapper = new Mapper(config);
            var addServiceDto = mapper.Map<AddMaintenanceTypeControllerDto, AddMaintenanceTypeServiceDto>(addDto);
            var result = await service.AddAsync(addServiceDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<MaintenanceTypeServiceDto, MaintenanceTypeControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(mapper2.Map<MaintenanceTypeServiceDto, MaintenanceTypeControllerDto>(result));
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MaintenanceTypeServiceDto,MaintenanceTypeControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(new MaintenanceTypeListControllerDto(){
                Items = (await service.GetAllAsync(count,offset)).Items.Select(x=>mapper.Map<MaintenanceTypeServiceDto,MaintenanceTypeControllerDto>(x))
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MaintenanceTypeServiceDto, MaintenanceTypeControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(mapper.Map<MaintenanceTypeServiceDto, MaintenanceTypeControllerDto>(await service.GetByIdAsync(id)));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
    [HttpPatch]
    [Route("update")]
    public async Task<IResult> UpdateAsync(UpdateMaintenanceTypeControllerDto updateDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateMaintenanceTypeControllerDto, UpdateMaintenanceTypeServiceDto>());
            var mapper = new Mapper(config);
            var updateServiceDto = mapper.Map<UpdateMaintenanceTypeControllerDto, UpdateMaintenanceTypeServiceDto>(updateDto);
            await service.UpdateAsync(updateServiceDto);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
}
