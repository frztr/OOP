
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace Global;
[ApiController]
[Route("RepairConsumedSparePart")]
public class RepairConsumedSparePartController(IRepairConsumedSparePartService service)
{
    [HttpPost]
    [Route("add")]
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RepairConsumedSparePartServiceDto,RepairConsumedSparePartControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(new RepairConsumedSparePartListControllerDto(){
                Items = (await service.GetAllAsync(count,offset)).Items.Select(x=>mapper.Map<RepairConsumedSparePartServiceDto,RepairConsumedSparePartControllerDto>(x))
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RepairConsumedSparePartServiceDto, RepairConsumedSparePartControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(mapper.Map<RepairConsumedSparePartServiceDto, RepairConsumedSparePartControllerDto>(await service.GetByIdAsync(id)));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
    [HttpPatch]
    [Route("update")]
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
            return Results.InternalServerError(ex);
        }
    }
}
