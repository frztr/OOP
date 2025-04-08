
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace Global;
[ApiController]
[Route("SparePart")]
public class SparePartController(ISparePartService service)
{
    [HttpPost]
    [Route("add")]
    public async Task<IResult> Add(AddSparePartControllerDto addDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddSparePartControllerDto, AddSparePartServiceDto>());
            var mapper = new Mapper(config);
            var addServiceDto = mapper.Map<AddSparePartControllerDto, AddSparePartServiceDto>(addDto);
            var result = await service.AddAsync(addServiceDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<SparePartServiceDto, SparePartControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(mapper2.Map<SparePartServiceDto, SparePartControllerDto>(result));
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SparePartServiceDto,SparePartControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(new SparePartListControllerDto(){
                Items = (await service.GetAllAsync(count,offset)).Items.Select(x=>mapper.Map<SparePartServiceDto,SparePartControllerDto>(x))
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SparePartServiceDto, SparePartControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(mapper.Map<SparePartServiceDto, SparePartControllerDto>(await service.GetByIdAsync(id)));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
    [HttpPatch]
    [Route("update")]
    public async Task<IResult> UpdateAsync(UpdateSparePartControllerDto updateDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateSparePartControllerDto, UpdateSparePartServiceDto>());
            var mapper = new Mapper(config);
            var updateServiceDto = mapper.Map<UpdateSparePartControllerDto, UpdateSparePartServiceDto>(updateDto);
            await service.UpdateAsync(updateServiceDto);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
}
