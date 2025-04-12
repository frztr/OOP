
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Mvc;
namespace Global;
[Authorize(Roles="admin")]
[ApiController]
[Route("RepairConsumedSparePart")]
public class RepairConsumedSparePartController(IRepairConsumedSparePartService service) : Controller
{
    [HttpPost]
    [Route("add")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<IResult> Add(AddRepairConsumedSparePartControllerDto addDto) 
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddRepairConsumedSparePartControllerDto, AddRepairConsumedSparePartServiceDto>());
            var mapper = new Mapper(config);
            var addServiceDto = mapper.Map<AddRepairConsumedSparePartControllerDto, AddRepairConsumedSparePartServiceDto>(addDto);
            var result = await service.AddAsync(addServiceDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<RepairConsumedSparePartServiceDto, RepairConsumedSparePartControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(mapper2.Map<RepairConsumedSparePartServiceDto, RepairConsumedSparePartControllerDto>(result));
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
    public async Task<IResult> GetAll([FromQuery]RepairConsumedSparePartQueryControllerDto queryDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RepairConsumedSparePartQueryControllerDto,RepairConsumedSparePartQueryServiceDto>());
            var mapper = new Mapper(config);
            var dto = mapper.Map<RepairConsumedSparePartQueryControllerDto,RepairConsumedSparePartQueryServiceDto>(queryDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<RepairConsumedSparePartServiceDto,RepairConsumedSparePartControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(new RepairConsumedSparePartListControllerDto(){
                Items = (await service.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<RepairConsumedSparePartServiceDto,RepairConsumedSparePartControllerDto>(x))
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RepairConsumedSparePartServiceDto, RepairConsumedSparePartControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(mapper.Map<RepairConsumedSparePartServiceDto, RepairConsumedSparePartControllerDto>(await service.GetByIdAsync(id)));
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
    public async Task<IResult> UpdateAsync(UpdateRepairConsumedSparePartControllerDto updateDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateRepairConsumedSparePartControllerDto, UpdateRepairConsumedSparePartServiceDto>());
            var mapper = new Mapper(config);
            var updateServiceDto = mapper.Map<UpdateRepairConsumedSparePartControllerDto, UpdateRepairConsumedSparePartServiceDto>(updateDto);
            await service.UpdateAsync(updateServiceDto);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(new {error = ex.Message});
        }
    }
}
