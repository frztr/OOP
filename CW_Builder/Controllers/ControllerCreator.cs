public class ControllerCreator
{
    public static string CreateController(Entity entity)
    {
        var pk = $@"{entity.Props.FirstOrDefault(x => x.Name == "Id").Type}";
        return $@"
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace Global;
[ApiController]
[Route(""{entity.Name}"")]
public class {entity.Name}Controller(I{entity.Name}Service service)
{{
    [HttpPost]
    [Route(""add"")]
    public IResult Add(Add{entity.Name}Dto addDto)
    {{
        try
        {{
            return Results.Json(service.Add(addDto));
        }}
        catch (Exception ex)
        {{
            return Results.InternalServerError(ex);
        }}
    }}

    [HttpDelete]
    [Route(""delete"")]
    public IResult Delete({pk} id)
    {{
        try
        {{
            service.Delete(id);
            return Results.Ok();
        }}
        catch (Exception ex)
        {{
            return Results.InternalServerError(ex);
        }}
    }}

    [HttpGet]
    [Route("""")]
    public IResult GetAll({pk} count = 50, {pk} offset = 0)
    {{
        try
        {{
            return Results.Json(service.GetAll(count,offset));
        }}
        catch (Exception ex)
        {{
            return Results.InternalServerError(ex);
        }}
    }}

    [HttpGet]
    [Route(""{{id}}"")]
    public IResult GetById({pk} id)
    {{
        try
        {{
            return Results.Json(service.GetById(id));
        }}
        catch (Exception ex)
        {{
            return Results.InternalServerError(ex);
        }}
    }}
    [HttpPatch]
    [Route(""update"")]
    public IResult Update(Update{entity.Name}Dto updateDto)
    {{
        try
        {{
            service.Update(updateDto);
            return Results.Ok();
        }}
        catch (Exception ex)
        {{
            return Results.InternalServerError(ex);
        }}
    }}
}}
";
    }
}