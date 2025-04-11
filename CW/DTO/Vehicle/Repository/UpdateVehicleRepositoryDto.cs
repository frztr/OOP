
using System.ComponentModel.DataAnnotations;
namespace Global;
public class UpdateVehicleRepositoryDto
{
    [Required]
	public int Id { get; set; }
	[StringLength(17)]
	public string? VinNumber { get; set; }
	[StringLength(15)]
	public string? PlateNumber { get; set; }
	public int? VehicleModelId { get; set; }
	public short? ReleaseYear { get; set; }
	public DateTime? RegistrationDate { get; set; }
	public short? StatusId { get; set; }
}