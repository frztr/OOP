
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Role.DTO;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace Role.Controller;

[ApiController]
[Route("Role")]
public class Controller : BaseController<short, AddDto, EntityDto, UpdateDto, AddDto, EntityDto, UpdateDto, IService>, IController
{
    public Controller(IService service) : base(service)
    {
    }
}