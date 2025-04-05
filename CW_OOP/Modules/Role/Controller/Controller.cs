
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Role.DTO;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace Role.Controller;

// [ApiController]
// [Route("Role")]
// public class Controller(IService service) : IController
// {
//     [HttpPost]
//     [Route("add")]
//     public IResult Add(DTO.AddDto addDto)
//     {
//         try
//         {
//             service.Add(addDto);
//             return Results.Created();
//         }
//         catch (Exception ex)
//         {
//             return Results.InternalServerError(ex);
//         }
//     }

//     [HttpDelete]
//     [Route("delete")]
//     public IResult Delete(short id)
//     {
//         try
//         {
//             service.Delete(id);
//             return Results.Ok();
//         }
//         catch (Exception ex)
//         {
//             return Results.InternalServerError(ex);
//         }
//     }

//     [HttpGet]
//     [Route("")]
//     public IResult GetAll()
//     {
//         try
//         {
//             return Results.Json(service.GetAll());
//         }
//         catch (Exception ex)
//         {
//             return Results.InternalServerError(ex);
//         }
//     }

//     [HttpGet]
//     [Route("{id}")]
//     public IResult GetById(short id)
//     {
//         try
//         {
//             return Results.Json(service.GetById(id));
//         }
//         catch (Exception ex)
//         {
//             return Results.InternalServerError(ex);
//         }
//     }
//     [HttpPatch]
//     [Route("update")]
//     public IResult Update(DTO.UpdateDto updateDto)
//     {
//         try
//         {
//             service.Update(updateDto);
//             return Results.Ok();
//         }
//         catch (Exception ex)
//         {
//             return Results.InternalServerError(ex);
//         }
//     }
// }

[ApiController]
[Route("Role")]
public class Controller : BaseController<short, AddDto, EntityDto, UpdateDto, AddDto, EntityDto, UpdateDto>
{
    public Controller(IBaseService<short, AddDto, UpdateDto, EntityDto> service) : base(service)
    {
    }
}