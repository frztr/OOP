using Microsoft.AspNetCore.Mvc;
using VehicleModel.DTO;

namespace VehicleModel.Controller;
public interface IController
{
    public IResult GetAll(int count = 50, int offset = 0);

    public IResult GetById(int id);

    public IResult Add(AddDto addDto);

    public IResult Delete(int id);

    public IResult Update(UpdateDto updateDto);
}
