
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using User.DTO;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace User.Controller;

[ApiController]
[Route("User")]
public class Controller(IService service) : IController
{
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