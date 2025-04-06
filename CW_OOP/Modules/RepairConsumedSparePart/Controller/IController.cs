using Microsoft.AspNetCore.Mvc;
using RepairConsumedSparePart.DTO;

namespace RepairConsumedSparePart.Controller;
public interface IController
{
    public IResult GetAll();

    public IResult GetById(short id);

    public IResult Add(AddDto addDto);

    public IResult Delete(short id);

    public IResult Update(UpdateDto updateDto);
}
