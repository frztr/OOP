using Microsoft.AspNetCore.Mvc;
using Role.DTO;

namespace Role.Controller;

public interface IController : IBaseController<short,AddDto,EntityDto,UpdateDto>
{

}
