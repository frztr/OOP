
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace Global;
[ApiController]
[Route("RefuelingHistory")]
public class RefuelingHistoryController(IRefuelingHistoryService service)
{
    [HttpPost]
    [Route("add")]
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RefuelingHistoryServiceDto,RefuelingHistoryControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(new RefuelingHistoryListControllerDto(){
                Items = (await service.GetAllAsync(count,offset)).Items.Select(x=>mapper.Map<RefuelingHistoryServiceDto,RefuelingHistoryControllerDto>(x))
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RefuelingHistoryServiceDto, RefuelingHistoryControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(mapper.Map<RefuelingHistoryServiceDto, RefuelingHistoryControllerDto>(await service.GetByIdAsync(id)));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
    [HttpPatch]
    [Route("update")]
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
            return Results.InternalServerError(ex);
        }
    }
}
