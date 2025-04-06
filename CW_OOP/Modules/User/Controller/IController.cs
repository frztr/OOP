using Microsoft.AspNetCore.Mvc;
using User.DTO;

namespace User.Controller;
public interface IController
{
    public IResult GetAll();

    public IResult GetById(short id);

    public IResult Delete(short id);

    public IResult Update(DTO.UpdateDto updateDto);
}
