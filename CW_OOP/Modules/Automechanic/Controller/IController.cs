using Microsoft.AspNetCore.Mvc;
using Automechanic.DTO;

namespace Automechanic.Controller;
public interface IController
{
    public IResult GetAll();

    public IResult GetById(short id);

    public IResult Add(AddServiceDto addDto);

    public IResult Delete(short id);

    public IResult Update(DTO.UpdateDto updateDto);
}
