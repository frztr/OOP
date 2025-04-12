
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Mvc;
namespace Global;
[Authorize(Roles="admin")]
[ApiController]
[Route("RefuelingHistory")]
public class RefuelingHistoryController(IRefuelingHistoryService service) : Controller
{
    [HttpPost]
    [Route("add")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<IResult> Add(AddRefuelingHistoryControllerDto addDto) 
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddRefuelingHistoryControllerDto, AddRefuelingHistoryServiceDto>());
            var mapper = new Mapper(config);
            var addServiceDto = mapper.Map<AddRefuelingHistoryControllerDto, AddRefuelingHistoryServiceDto>(addDto);
            var result = await service.AddAsync(addServiceDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<RefuelingHistoryServiceDto, RefuelingHistoryControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(mapper2.Map<RefuelingHistoryServiceDto, RefuelingHistoryControllerDto>(result));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.InnerException.ToString()} {ex.Source} {ex.Data}");
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
    public async Task<IResult> GetAll([FromQuery]RefuelingHistoryQueryControllerDto queryDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RefuelingHistoryQueryControllerDto,RefuelingHistoryQueryServiceDto>());
            var mapper = new Mapper(config);
            var dto = mapper.Map<RefuelingHistoryQueryControllerDto,RefuelingHistoryQueryServiceDto>(queryDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<RefuelingHistoryServiceDto,RefuelingHistoryControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(new RefuelingHistoryListControllerDto(){
                Items = (await service.GetAllAsync(dto)).Items.Select(x=>mapper2.Map<RefuelingHistoryServiceDto,RefuelingHistoryControllerDto>(x))
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RefuelingHistoryServiceDto, RefuelingHistoryControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(mapper.Map<RefuelingHistoryServiceDto, RefuelingHistoryControllerDto>(await service.GetByIdAsync(id)));
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
    public async Task<IResult> UpdateAsync(UpdateRefuelingHistoryControllerDto updateDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateRefuelingHistoryControllerDto, UpdateRefuelingHistoryServiceDto>());
            var mapper = new Mapper(config);
            var updateServiceDto = mapper.Map<UpdateRefuelingHistoryControllerDto, UpdateRefuelingHistoryServiceDto>(updateDto);
            await service.UpdateAsync(updateServiceDto);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(new {error = ex.Message});
        }
    }
}
