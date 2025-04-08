
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace Global;
[ApiController]
[Route("FuelType")]
public class FuelTypeController(IFuelTypeService service)
{
    [HttpPost]
    [Route("add")]
    public async Task<IResult> Add(AddFuelTypeControllerDto addDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddFuelTypeControllerDto, AddFuelTypeServiceDto>());
            var mapper = new Mapper(config);
            var addServiceDto = mapper.Map<AddFuelTypeControllerDto, AddFuelTypeServiceDto>(addDto);
            var result = await service.AddAsync(addServiceDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<FuelTypeServiceDto, FuelTypeControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(mapper2.Map<FuelTypeServiceDto, FuelTypeControllerDto>(result));
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FuelTypeServiceDto,FuelTypeControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(new FuelTypeListControllerDto(){
                Items = (await service.GetAllAsync(count,offset)).Items.Select(x=>mapper.Map<FuelTypeServiceDto,FuelTypeControllerDto>(x))
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FuelTypeServiceDto, FuelTypeControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(mapper.Map<FuelTypeServiceDto, FuelTypeControllerDto>(await service.GetByIdAsync(id)));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
    [HttpPatch]
    [Route("update")]
    public async Task<IResult> UpdateAsync(UpdateFuelTypeControllerDto updateDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateFuelTypeControllerDto, UpdateFuelTypeServiceDto>());
            var mapper = new Mapper(config);
            var updateServiceDto = mapper.Map<UpdateFuelTypeControllerDto, UpdateFuelTypeServiceDto>(updateDto);
            await service.UpdateAsync(updateServiceDto);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
}
