using Microsoft.AspNetCore.Mvc;
using Role.DTO;

namespace Role.Controller;
// public interface IController
// {
//     public IResult GetAll();

//     public IResult GetById(short id);

//     public IResult Add(DTO.AddDto addDto);

//     public IResult Delete(short id);

//     public IResult Update(DTO.UpdateDto updateDto);
// }

public interface IController : IBaseController<short,AddDto,EntityDto,UpdateDto>
{

}
