
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using FuelType.DTO;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace FuelType.Controller;

[ApiController]
[Route("FuelType")]
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
    public IResult Delete(short id)
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
    public IResult GetAll()
    {
        try
        {
            return Results.Json(service.GetAll());
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex);
        }
    }

    [HttpGet]
    [Route("{id}")]
    public IResult GetById(short id)
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