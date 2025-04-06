
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VehiclePhoto.DTO;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace VehiclePhoto.Controller;

[ApiController]
[Route("VehiclePhoto")]
public class Controller(IService service) : IController
{
    [HttpPost]
    [Route("add")]
    public IResult Add(AddServiceDto addDto)
    {
        try
        {
            return Results.Json(service.Add(addDto));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }

    [HttpDelete]
    [Route("delete")]
    public IResult Delete(int id)
    {
        try
        {
            service.Delete(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }

    [HttpGet]
    [Route("getPhotosByVehicleId")]
    public IResult GetPhotosByVehicleId(int vehicleId)
    {
        try
        {
            return Results.Json(service.GetByVehicleId(vehicleId));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
}