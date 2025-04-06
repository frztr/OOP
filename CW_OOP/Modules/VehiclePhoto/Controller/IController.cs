namespace VehiclePhoto.Controller;
public interface IController
{
    public IResult GetPhotosByVehicleId(int id);

    public IResult Add(AddServiceDto addDto);

    public IResult Delete(int id);
}
