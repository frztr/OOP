
namespace Global;
public class UpdateDriverControllerDto
{
    public short Id { get; set; }
    public short? UserId { get; set; }
	public long? DriverLicense { get; set; }
	public short? Experience { get; set; }
}