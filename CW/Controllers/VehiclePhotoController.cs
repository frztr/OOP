
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace Global;
[ApiController]
[Route("VehiclePhoto")]
public class VehiclePhotoController(IVehiclePhotoService service)
{
    [HttpPost]
    [Route("add")]
    public async Task<IResult> Add(AddVehiclePhotoControllerDto addDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddVehiclePhotoControllerDto, AddVehiclePhotoServiceDto>());
            var mapper = new Mapper(config);
            var addServiceDto = mapper.Map<AddVehiclePhotoControllerDto, AddVehiclePhotoServiceDto>(addDto);
            var result = await service.AddAsync(addServiceDto);
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<VehiclePhotoServiceDto, VehiclePhotoControllerDto>());
            var mapper2 = new Mapper(config2);
            return Results.Json(mapper2.Map<VehiclePhotoServiceDto, VehiclePhotoControllerDto>(result));
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<VehiclePhotoServiceDto,VehiclePhotoControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(new VehiclePhotoListControllerDto(){
                Items = (await service.GetAllAsync(count,offset)).Items.Select(x=>mapper.Map<VehiclePhotoServiceDto,VehiclePhotoControllerDto>(x))
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<VehiclePhotoServiceDto, VehiclePhotoControllerDto>());
            var mapper = new Mapper(config);
            return Results.Json(mapper.Map<VehiclePhotoServiceDto, VehiclePhotoControllerDto>(await service.GetByIdAsync(id)));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
    [HttpPatch]
    [Route("update")]
    public async Task<IResult> UpdateAsync(UpdateVehiclePhotoControllerDto updateDto)
    {
        try
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateVehiclePhotoControllerDto, UpdateVehiclePhotoServiceDto>());
            var mapper = new Mapper(config);
            var updateServiceDto = mapper.Map<UpdateVehiclePhotoControllerDto, UpdateVehiclePhotoServiceDto>(updateDto);
            await service.UpdateAsync(updateServiceDto);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
}
