using Microsoft.AspNetCore.Mvc;
using MileageMeasurementHistory.DTO;

namespace MileageMeasurementHistory.Controller;
public interface IController
{
    public IResult GetAll();

    public IResult GetById(short id);

    public IResult Add(AddDto addDto);

    public IResult Delete(short id);

    public IResult Update(UpdateDto updateDto);
}
