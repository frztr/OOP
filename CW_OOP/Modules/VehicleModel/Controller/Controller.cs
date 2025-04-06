
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VehicleModel.DTO;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace VehicleModel.Controller;

[ApiController]
[Route("VehicleModel")]
public class Controller(IService service) : IController
{
    [HttpPost]
    [Route("add")]
    public IResult Add(DTO.AddDto addDto)
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
    [Route("")]
    public IResult GetAll(int count = 50, int offset = 0)
    {
        try
        {
            return Results.Json(service.GetAll(count, offset));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }

    [HttpGet]
    [Route("{id}")]
    public IResult GetById(int id)
    {
        try
        {
            return Results.Json(service.GetById(id));
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
    [HttpPatch]
    [Route("update")]
    public IResult Update(DTO.UpdateDto updateDto)
    {
        try
        {
            service.Update(updateDto);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }
}