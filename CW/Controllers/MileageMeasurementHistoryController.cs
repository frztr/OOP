
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace Global;
[ApiController]
[Route("MileageMeasurementHistory")]
public class MileageMeasurementHistoryController(IMileageMeasurementHistoryService service)
{
    [HttpPost]
    [Route("add")]
    public async Task<IResult> Add(AddMileageMeasurementHistoryControllerDto addDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddMileageMeasurementHistoryControllerDto, AddMileageMeasurementHistoryServiceDto>());
            var mapper = new Mapper(config);
            var addServiceDto = mapper.Map<AddMileageMeasurementHistoryControllerDto, AddMileageMeasurementHistoryServiceDto>(addDto);
            var result = await service.AddAsync(addServiceDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<MileageMeasurementHistoryServiceDto, MileageMeasurementHistoryControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(mapper2.Map<MileageMeasurementHistoryServiceDto, MileageMeasurementHistoryControllerDto>(result));
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MileageMeasurementHistoryServiceDto,MileageMeasurementHistoryControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(new MileageMeasurementHistoryListControllerDto(){
                Items = (await service.GetAllAsync(count,offset)).Items.Select(x=>mapper.Map<MileageMeasurementHistoryServiceDto,MileageMeasurementHistoryControllerDto>(x))
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MileageMeasurementHistoryServiceDto, MileageMeasurementHistoryControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(mapper.Map<MileageMeasurementHistoryServiceDto, MileageMeasurementHistoryControllerDto>(await service.GetByIdAsync(id)));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
    [HttpPatch]
    [Route("update")]
    public async Task<IResult> UpdateAsync(UpdateMileageMeasurementHistoryControllerDto updateDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateMileageMeasurementHistoryControllerDto, UpdateMileageMeasurementHistoryServiceDto>());
            var mapper = new Mapper(config);
            var updateServiceDto = mapper.Map<UpdateMileageMeasurementHistoryControllerDto, UpdateMileageMeasurementHistoryServiceDto>(updateDto);
            await service.UpdateAsync(updateServiceDto);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
}
