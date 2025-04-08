
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace Global;
[ApiController]
[Route("Driver")]
public class DriverController(IDriverService service)
{
    [HttpPost]
    [Route("add")]
    public async Task<IResult> Add(AddDriverControllerDto addDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddDriverControllerDto, AddDriverServiceDto>());
            var mapper = new Mapper(config);
            var addServiceDto = mapper.Map<AddDriverControllerDto, AddDriverServiceDto>(addDto);
            var result = await service.AddAsync(addServiceDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<DriverServiceDto, DriverControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(mapper2.Map<DriverServiceDto, DriverControllerDto>(result));
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DriverServiceDto,DriverControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(new DriverListControllerDto(){
                Items = (await service.GetAllAsync(count,offset)).Items.Select(x=>mapper.Map<DriverServiceDto,DriverControllerDto>(x))
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DriverServiceDto, DriverControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(mapper.Map<DriverServiceDto, DriverControllerDto>(await service.GetByIdAsync(id)));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
    [HttpPatch]
    [Route("update")]
    public async Task<IResult> UpdateAsync(UpdateDriverControllerDto updateDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateDriverControllerDto, UpdateDriverServiceDto>());
            var mapper = new Mapper(config);
            var updateServiceDto = mapper.Map<UpdateDriverControllerDto, UpdateDriverServiceDto>(updateDto);
            await service.UpdateAsync(updateServiceDto);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
}
