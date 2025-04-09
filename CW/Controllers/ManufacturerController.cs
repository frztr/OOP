
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Mvc;
namespace Global;
[Authorize(Roles="admin")]
[ApiController]
[Route("Manufacturer")]
public class ManufacturerController(IManufacturerService service) : Controller
{
    [HttpPost]
    [Route("add")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<IResult> Add(AddManufacturerControllerDto addDto) 
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddManufacturerControllerDto, AddManufacturerServiceDto>());
            var mapper = new Mapper(config);
            var addServiceDto = mapper.Map<AddManufacturerControllerDto, AddManufacturerServiceDto>(addDto);
            var result = await service.AddAsync(addServiceDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<ManufacturerServiceDto, ManufacturerControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(mapper2.Map<ManufacturerServiceDto, ManufacturerControllerDto>(result));
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
    public async Task<IResult> GetAll([FromQuery]ManufacturerQueryControllerDto queryDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ManufacturerQueryControllerDto,ManufacturerQueryServiceDto>());
            var mapper = new Mapper(config);
            var dto = mapper.Map<ManufacturerQueryControllerDto,ManufacturerQueryServiceDto>(queryDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<ManufacturerServiceDto,ManufacturerControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(new ManufacturerListControllerDto(){
                Items = (await service.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<ManufacturerServiceDto,ManufacturerControllerDto>(x))
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ManufacturerServiceDto, ManufacturerControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(mapper.Map<ManufacturerServiceDto, ManufacturerControllerDto>(await service.GetByIdAsync(id)));
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
    public async Task<IResult> UpdateAsync(UpdateManufacturerControllerDto updateDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateManufacturerControllerDto, UpdateManufacturerServiceDto>());
            var mapper = new Mapper(config);
            var updateServiceDto = mapper.Map<UpdateManufacturerControllerDto, UpdateManufacturerServiceDto>(updateDto);
            await service.UpdateAsync(updateServiceDto);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
}
