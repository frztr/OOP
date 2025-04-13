
namespace Global;
public class VehicleServiceDto
{
    public int Id { get; set; }
	public string VinNumber { get; set; }
	public string PlateNumber { get; set; }
	public int VehiclemodelId { get; set; }
	public short ReleaseYear { get; set; }
	public DateTime RegistrationDate { get; set; }
	public short StatusId { get; set; }
}