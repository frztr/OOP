
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Mvc;
namespace Global;
[Authorize(Roles="admin")]
[ApiController]
[Route("VehicleDocument")]
public class VehicleDocumentController(IVehicleDocumentService service) : Controller
{
    [HttpPost]
    [Route("add")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IResult> Add(AddVehicleDocumentControllerDto addDto) 
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddVehicleDocumentControllerDto, AddVehicleDocumentServiceDto>());
            var mapper = new Mapper(config);
            var addServiceDto = mapper.Map<AddVehicleDocumentControllerDto, AddVehicleDocumentServiceDto>(addDto);
            var result = await service.AddAsync(addServiceDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehicleDocumentServiceDto, VehicleDocumentControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(mapper2.Map<VehicleDocumentServiceDto, VehicleDocumentControllerDto>(result));
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
    public async Task<IResult> Delete(int id)
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
    public async Task<IResult> GetAll([FromQuery]VehicleDocumentQueryControllerDto queryDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleDocumentQueryControllerDto,VehicleDocumentQueryServiceDto>());
            var mapper = new Mapper(config);
            var dto = mapper.Map<VehicleDocumentQueryControllerDto,VehicleDocumentQueryServiceDto>(queryDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehicleDocumentServiceDto,VehicleDocumentControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(new VehicleDocumentListControllerDto(){
                Items = (await service.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<VehicleDocumentServiceDto,VehicleDocumentControllerDto>(x))
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
    public async Task<IResult> GetById(int id)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleDocumentServiceDto, VehicleDocumentControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(mapper.Map<VehicleDocumentServiceDto, VehicleDocumentControllerDto>(await service.GetByIdAsync(id)));
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
    public async Task<IResult> UpdateAsync(UpdateVehicleDocumentControllerDto updateDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateVehicleDocumentControllerDto, UpdateVehicleDocumentServiceDto>());
            var mapper = new Mapper(config);
            var updateServiceDto = mapper.Map<UpdateVehicleDocumentControllerDto, UpdateVehicleDocumentServiceDto>(updateDto);
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
