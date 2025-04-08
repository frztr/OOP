
namespace Global;
public class UpdateVehicleDocumentControllerDto
{
    public int Id { get; set; }
    public short? DocTypeId { get; set; }
	public string? Src { get; set; }
	public int? VehicleId { get; set; }
}