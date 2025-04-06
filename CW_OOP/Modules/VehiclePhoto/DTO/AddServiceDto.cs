namespace VehiclePhoto.DTO;
public class AddServiceDto
{
    public IFormFileCollection photos { get; set; }

    public int VehicleId { get; set; }
}