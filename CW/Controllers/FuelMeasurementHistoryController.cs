
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace Global;
[ApiController]
[Route("FuelMeasurementHistory")]
public class FuelMeasurementHistoryController(IFuelMeasurementHistoryService service)
{
    [HttpPost]
    [Route("add")]
    public async Task<IResult> Add(AddFuelMeasurementHistoryControllerDto addDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddFuelMeasurementHistoryControllerDto, AddFuelMeasurementHistoryServiceDto>());
            var mapper = new Mapper(config);
            var addServiceDto = mapper.Map<AddFuelMeasurementHistoryControllerDto, AddFuelMeasurementHistoryServiceDto>(addDto);
            var result = await service.AddAsync(addServiceDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<FuelMeasurementHistoryServiceDto, FuelMeasurementHistoryControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(mapper2.Map<FuelMeasurementHistoryServiceDto, FuelMeasurementHistoryControllerDto>(result));
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FuelMeasurementHistoryServiceDto,FuelMeasurementHistoryControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(new FuelMeasurementHistoryListControllerDto(){
                Items = (await service.GetAllAsync(count,offset)).Items.Select(x=>mapper.Map<FuelMeasurementHistoryServiceDto,FuelMeasurementHistoryControllerDto>(x))
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FuelMeasurementHistoryServiceDto, FuelMeasurementHistoryControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(mapper.Map<FuelMeasurementHistoryServiceDto, FuelMeasurementHistoryControllerDto>(await service.GetByIdAsync(id)));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
    [HttpPatch]
    [Route("update")]
    public async Task<IResult> UpdateAsync(UpdateFuelMeasurementHistoryControllerDto updateDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateFuelMeasurementHistoryControllerDto, UpdateFuelMeasurementHistoryServiceDto>());
            var mapper = new Mapper(config);
            var updateServiceDto = mapper.Map<UpdateFuelMeasurementHistoryControllerDto, UpdateFuelMeasurementHistoryServiceDto>(updateDto);
            await service.UpdateAsync(updateServiceDto);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
}
