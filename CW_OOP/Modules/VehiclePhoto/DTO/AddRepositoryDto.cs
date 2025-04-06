namespace VehiclePhoto.DTO;
public class AddDto
{
    public string Src { get; set; }

    public int VehicleId { get; set; }

    public Global.VehiclePhoto Convert()
    {
        return new Global.VehiclePhoto()
        {
            Src = Src,
            VehicleId = VehicleId
        };
    }
}