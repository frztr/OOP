
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace Global;
[ApiController]
[Route("VehicleDocument")]
public class VehicleDocumentController(IVehicleDocumentService service)
{
    [HttpPost]
    [Route("add")]
    public async Task<IResult> Add(AddVehicleDocumentControllerDto addDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddVehicleDocumentControllerDto, AddVehicleDocumentServiceDto>());
            var mapper = new Mapper(config);
            var addServiceDto = mapper.Map<AddVehicleDocumentControllerDto, AddVehicleDocumentServiceDto>(addDto);
            var result = await service.AddAsync(addServiceDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehicleDocumentServiceDto, VehicleDocumentControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(mapper2.Map<VehicleDocumentServiceDto, VehicleDocumentControllerDto>(result));
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleDocumentServiceDto,VehicleDocumentControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(new VehicleDocumentListControllerDto(){
                Items = (await service.GetAllAsync(count,offset)).Items.Select(x=>mapper.Map<VehicleDocumentServiceDto,VehicleDocumentControllerDto>(x))
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleDocumentServiceDto, VehicleDocumentControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(mapper.Map<VehicleDocumentServiceDto, VehicleDocumentControllerDto>(await service.GetByIdAsync(id)));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
    [HttpPatch]
    [Route("update")]
    public async Task<IResult> UpdateAsync(UpdateVehicleDocumentControllerDto updateDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateVehicleDocumentControllerDto, UpdateVehicleDocumentServiceDto>());
            var mapper = new Mapper(config);
            var updateServiceDto = mapper.Map<UpdateVehicleDocumentControllerDto, UpdateVehicleDocumentServiceDto>(updateDto);
            await service.UpdateAsync(updateServiceDto);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
}
