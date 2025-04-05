using Microsoft.AspNetCore.Mvc;

namespace Driver.Controller;
public interface IController
{
    public IResult GetAll();

    public IResult GetById(short id);

    public IResult Add(DTO.AddDto addDto);

    public IResult Delete(short id);

    public IResult Update(DTO.UpdateDto updateDto);
}
