
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Mvc;
namespace Global;
[Authorize(Roles="admin")]
[ApiController]
[Route("VehicleStatus")]
public class VehicleStatusController(IVehicleStatusService service) : Controller
{
    [HttpPost]
    [Route("add")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IResult> Add(AddVehicleStatusControllerDto addDto) 
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddVehicleStatusControllerDto, AddVehicleStatusServiceDto>());
            var mapper = new Mapper(config);
            var addServiceDto = mapper.Map<AddVehicleStatusControllerDto, AddVehicleStatusServiceDto>(addDto);
            var result = await service.AddAsync(addServiceDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehicleStatusServiceDto, VehicleStatusControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(mapper2.Map<VehicleStatusServiceDto, VehicleStatusControllerDto>(result));
        }
        catch (EntityNotFoundException ex)
        {
            return Results.BadRequest(new {error = ex.Message});
        }
        catch (DbUpdateException ex)
        when ((ex.InnerException as Npgsql.PostgresException).SqlState == "23505")
        {
            var innerEx = (ex.InnerException as Npgsql.PostgresException);
            return Results.BadRequest(new { error = $"Нарушение уникальности поля {innerEx.ConstraintName.Split("_").LastOrDefault()}" });
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(new {error = ex.Message});
        }
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IResult> Delete(short id)
    {
        try
        {
            await service.DeleteAsync(id);
            return Results.Ok();
        }
        catch (EntityNotFoundException ex)
        {
            return Results.BadRequest(new {error = ex.Message});
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(new {error = ex.Message}); 
        }
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IResult> GetAll([FromQuery]VehicleStatusQueryControllerDto queryDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleStatusQueryControllerDto,VehicleStatusQueryServiceDto>());
            var mapper = new Mapper(config);
            var dto = mapper.Map<VehicleStatusQueryControllerDto,VehicleStatusQueryServiceDto>(queryDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehicleStatusServiceDto,VehicleStatusControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(new VehicleStatusListControllerDto(){
                Items = (await service.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<VehicleStatusServiceDto,VehicleStatusControllerDto>(x))
            });
        }
        catch (EntityNotFoundException ex)
        {
            return Results.BadRequest(new {error = ex.Message});
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(new {error = ex.Message});
        }
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IResult> GetById(short id)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleStatusServiceDto, VehicleStatusControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(mapper.Map<VehicleStatusServiceDto, VehicleStatusControllerDto>(await service.GetByIdAsync(id)));
        }
        catch (EntityNotFoundException ex)
        {
            return Results.BadRequest(new {error = ex.Message});
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(new {error = ex.Message});
        }
    }
    [HttpPatch]
    [Route("update")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IResult> UpdateAsync(UpdateVehicleStatusControllerDto updateDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateVehicleStatusControllerDto, UpdateVehicleStatusServiceDto>());
            var mapper = new Mapper(config);
            var updateServiceDto = mapper.Map<UpdateVehicleStatusControllerDto, UpdateVehicleStatusServiceDto>(updateDto);
            await service.UpdateAsync(updateServiceDto);
            return Results.Ok();
        }
        catch (EntityNotFoundException ex)
        {
            return Results.BadRequest(new {error = ex.Message});
        }
        catch (DbUpdateException ex)
        when ((ex.InnerException as Npgsql.PostgresException).SqlState == "23505")
        {
            var innerEx = (ex.InnerException as Npgsql.PostgresException);
            return Results.BadRequest(new { error = $"Нарушение уникальности поля {innerEx.ConstraintName.Split("_").LastOrDefault()}" });
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(new {error = ex.Message});
        }
    }
}
