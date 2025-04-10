
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Mvc;
namespace Global;
[Authorize(Roles="admin")]
[ApiController]
[Route("RepairHistory")]
public class RepairHistoryController(IRepairHistoryService service) : Controller
{
    [HttpPost]
    [Route("add")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<IResult> Add(AddRepairHistoryControllerDto addDto) 
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddRepairHistoryControllerDto, AddRepairHistoryServiceDto>());
            var mapper = new Mapper(config);
            var addServiceDto = mapper.Map<AddRepairHistoryControllerDto, AddRepairHistoryServiceDto>(addDto);
            var result = await service.AddAsync(addServiceDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<RepairHistoryServiceDto, RepairHistoryControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(mapper2.Map<RepairHistoryServiceDto, RepairHistoryControllerDto>(result));
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
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<IResult> GetAll([FromQuery]RepairHistoryQueryControllerDto queryDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RepairHistoryQueryControllerDto,RepairHistoryQueryServiceDto>());
            var mapper = new Mapper(config);
            var dto = mapper.Map<RepairHistoryQueryControllerDto,RepairHistoryQueryServiceDto>(queryDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<RepairHistoryServiceDto,RepairHistoryControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(new RepairHistoryListControllerDto(){
                Items = (await service.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<RepairHistoryServiceDto,RepairHistoryControllerDto>(x))
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
    public async Task<IResult> GetById(int id)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RepairHistoryServiceDto, RepairHistoryControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(mapper.Map<RepairHistoryServiceDto, RepairHistoryControllerDto>(await service.GetByIdAsync(id)));
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
    public async Task<IResult> UpdateAsync(UpdateRepairHistoryControllerDto updateDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateRepairHistoryControllerDto, UpdateRepairHistoryServiceDto>());
            var mapper = new Mapper(config);
            var updateServiceDto = mapper.Map<UpdateRepairHistoryControllerDto, UpdateRepairHistoryServiceDto>(updateDto);
            await service.UpdateAsync(updateServiceDto);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
}
