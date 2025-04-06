using Microsoft.AspNetCore.Mvc;
using Driver.DTO;

namespace Driver.Controller;
public interface IController
{
    public IResult GetAll();

    public IResult GetById(short id);

    public IResult Add(AddServiceDto addDto);

    public IResult Delete(short id);

    public IResult Update(UpdateDto updateDto);

    public IResult GetRefuels(short id, int count = 50, int offset = 0);
}
